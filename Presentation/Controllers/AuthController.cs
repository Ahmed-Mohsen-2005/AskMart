using Application.Contracts.Services;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IApiResponseFactory _responseFactory;

        public AuthController(IAuthService authService, IApiResponseFactory responseFactory)
        {
            _authService = authService;
            _responseFactory = responseFactory;
        }



        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _authService.RegisterAsync(
                request.Username,
                request.Email,
                request.Address,
                request.Password);

            return StatusCode((int)response.StatusCode, response);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(
                request.Username,
                request.Password);

            return StatusCode((int)response.StatusCode, response);
        }

        // POST: api/auth/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var response = await _authService.ForgotPasswordAsync(request.Email);
            return StatusCode((int)response.StatusCode, response);
        }

        // POST: api/auth/reset-password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = await _authService.ResetPasswordAsync(
                request.Email,
                request.Token,
                request.NewPassword);

            return StatusCode((int)response.StatusCode, response);
        }
    }


}
