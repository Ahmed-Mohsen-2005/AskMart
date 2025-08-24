using Application.Contracts;
using Domain.Entities.User;
using Domain.Results;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Implementations
{
    public class AuthService : IAuthService
    {
        // Dependencies
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        // implemented from IAuthService
        // Registration method
        public async Task<Response<AuthResult>> RegisterAsync(string username, string email, string address, string password)
        {
            // 1) Check if user already exists
            var existingUser = await _userManager.FindByNameAsync(username)
                               ?? await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                return new Response<AuthResult>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Succeeded = false,
                    Message = "User with the same username or email already exists"
                };
            }


            // 2) Create the user entity
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                Address = address
            };

            // 3) Save to DB
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return new Response<AuthResult>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Succeeded = false,
                    Message = "Registration failed",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            // 4) Generate JWT + AuthResult
            var authResult = await GenerateAuthResult(user);

            // 6) Return wrapped response
            return new Response<AuthResult>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "User registered successfully",
                Data = authResult
            };
        }

        //helper method to generate JWT token and AuthResult
        private async Task<AuthResult> GenerateAuthResult(ApplicationUser user)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new AuthResult
            {
                UserId = user.Id.GetHashCode(),
                IsAuthenticated = true,
                Username = user.UserName,
                Email = user.Email,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpiration = DateTime.UtcNow.AddDays(7)
            };
        }


        // Login method
        public async Task<Response<AuthResult>> LoginAsync(string username, string password)
        {
            // 1) Look up user
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return new Response<AuthResult>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "User not found"
                };
            }

            // 2) Verify password
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
            {
                return new Response<AuthResult>
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Succeeded = false,
                    Message = "Invalid password"
                };
            }

            // 3) Generate JWT + AuthResult
            var authResult = await GenerateAuthResult(user);

            // 4) Return wrapped response
            return new Response<AuthResult>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Login successful",
                Data = authResult
            };
        }

        // forget password 
        public async Task<Response<string>> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new Response<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "User with this email does not exist"
                };
            }

            // Generate reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Password reset token generated",
                Data = token
            };
        }

        // reset password 
        public async Task<Response<string>> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new Response<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "User with this email does not exist"
                };
            }

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
            {
                return new Response<string>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Succeeded = false,
                    Message = "Password reset failed",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Password reset successful"
            };

           
        }

    }
    
}
