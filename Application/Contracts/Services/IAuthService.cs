using Domain.Results;

namespace Application.Contracts.Services
{
    public interface IAuthService
    {
        //using task because these methods will be async
        Task<Response<AuthResult>> RegisterAsync(string username, string email, string address, string password, string phoneNumber);
        Task<Response<AuthResult>> LoginAsync(string username, string password);

        // for forget password functionality 
        Task<Response<string>> ForgotPasswordAsync(string email);
        Task<Response<string>> ResetPasswordAsync(string email, string token, string newPassword);
    }
}
