using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IUserService
    {
        Task<string> RegisterUserAsync(User user); // Asynchronous registration
        Task<string> AuthenticateUserAsync(string email, string password); // Asynchronous authentication
        Task<User> GetUserByEmailAsync(string email);
    }
}
