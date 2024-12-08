//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;


//namespace AsmrsBackend.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly AppDbContext _context;

//        public UserRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task AddUserAsync(User user)
//        {
//            await _context.Users.AddAsync(user); // Add asynchronously
//            await _context.SaveChangesAsync();   // Save changes asynchronously
//        }

//        public async Task<User> GetUserByEmailAsync(string email)
//        {
//            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email); // Fetch asynchronously
//        }

//        public async Task<User> GetUserByIdAsync(int id)
//        {
//            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id); // Fetch asynchronously
//        }
//    }
//}


using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public async Task AddUserAsync(User user)
        {
            await _users.InsertOneAsync(user); // Insert user asynchronously
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _users.Find(u => u.Email == email).FirstOrDefaultAsync(); // Fetch user by email
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync(); // Fetch user by id
        }
    }
}
