//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IUserRepository
//    {
//        Task AddUserAsync(User user);
//        Task<User> GetUserByEmailAsync(string email);
//        Task<User> GetUserByIdAsync(int id);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(string id);
    }
}
