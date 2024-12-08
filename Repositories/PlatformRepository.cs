//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class PlatformRepository : IPlatformRepository
//    {
//        private readonly AppDbContext _context;

//        public PlatformRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Platform> GetPlatformByIdAsync(int platformId)
//        {
//            return await _context.Platforms.FindAsync(platformId);
//        }

//        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
//        {
//            return await _context.Platforms.ToListAsync();
//        }

//        public async Task CreatePlatformAsync(Platform platform)
//        {
//            await _context.Platforms.AddAsync(platform);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdatePlatformAsync(Platform platform)
//        {
//            _context.Platforms.Update(platform);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeletePlatformAsync(int platformId)
//        {
//            var platform = await _context.Platforms.FindAsync(platformId);
//            if (platform != null)
//            {
//                _context.Platforms.Remove(platform);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}


using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly IMongoCollection<Platform> _platforms;

        public PlatformRepository(IMongoDatabase database)
        {
            _platforms = database.GetCollection<Platform>("Platforms");
        }

        public async Task<Platform> GetPlatformByIdAsync(string platformId)
        {
            return await _platforms.Find(p => p.PlatformId == platformId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await _platforms.Find(_ => true).ToListAsync();
        }

        public async Task CreatePlatformAsync(Platform platform)
        {
            await _platforms.InsertOneAsync(platform);
        }

        public async Task UpdatePlatformAsync(Platform platform)
        {
            await _platforms.ReplaceOneAsync(p => p.PlatformId == platform.PlatformId, platform);
        }

        public async Task DeletePlatformAsync(string platformId)
        {
            await _platforms.DeleteOneAsync(p => p.PlatformId == platformId);
        }
    }
}
