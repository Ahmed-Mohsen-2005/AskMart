using Application.Contracts;
using Domain.Entities;
using Domain.Results;
using Infrastructure.Persistence;
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
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        // implemented from IAuthService
        // Registration method
        public async Task<Response<AuthResult>> RegisterAsync(string username, string email, string address, string password)
        {
            // 1) Check if user already exists
            if (await _db.Users.AnyAsync(u => u.Username == username || u.Email == email))
            {
                return new Response<AuthResult>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Succeeded = false,
                    Message = "User with the same username or email already exists"
                };
            }

            // 2) Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // 3) Create the user entity
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = email,
                Address = address,
                PasswordHash = hashedPassword
            };

            // 4) Save to DB
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            // 5) Generate JWT + AuthResult
            var authResult = GenerateAuthResult(user);

            // 6) Return wrapped response
            return new Response<AuthResult>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "User registered successfully",
                Data = authResult
            };
        }

        // Helper method: Generate JWT
        private AuthResult GenerateAuthResult(User user)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new AuthResult
            {
                UserId = user.Id.GetHashCode(), // could map properly if needed
                IsAuthenticated = true,
                Username = user.Username,
                Email = user.Email,
                Roles = new List<string>(), // no roles yet
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
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

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
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return new Response<AuthResult>
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Succeeded = false,
                    Message = "Invalid password"
                };
            }

            // 3) Generate JWT + AuthResult
            var authResult = GenerateAuthResult(user);

            // 4) Return wrapped response
            return new Response<AuthResult>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Login successful",
                Data = authResult
            };
        }

    }
}
