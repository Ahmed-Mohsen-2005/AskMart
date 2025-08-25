using Application.Contracts;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : AppControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _authService.CustomerRegisterAsync(
                request.Username,
                request.Email,
                request.Address,
                request.Password,
                UserType.Customer);

            return NewResult(response); // instead of StatusCode(...)
        }

        // POST: api/auth/admin/register
        [HttpPost("admin/register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminRegister([FromBody] RegisterRequest request)
        {
            var response = await _authService.AdminRegisterAsync(
                request.Username,
                request.Email,
                request.Address,
                request.Password,
                UserType.Admin);

            return NewResult(response); // instead of StatusCode(...)
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(
                request.Username,
                request.Password);

            return NewResult(response);
        }
        // POST: api/auth/admin/login
        [HttpPost("admin/login")]
        
        public async Task<IActionResult> AdminLogin([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(
                request.Username,
                request.Password);

            return NewResult(response);
        }

        // POST: api/auth/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var response = await _authService.ForgotPasswordAsync(request.Email);
            return NewResult(response);
        }

        // POST: api/auth/reset-password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = await _authService.ResetPasswordAsync(
                request.Email,
                request.Token,
                request.NewPassword);

            return NewResult(response);
        }
    }


}
