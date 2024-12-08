//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class MapRepository : IMapRepository
//    {
//        private readonly AppDbContext _context;

//        public MapRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Map> GetMapByIdAsync(int mapId)
//        {
//            return await _context.Maps.FindAsync(mapId);
//        }

//        public async Task<IEnumerable<Map>> GetAllMapsAsync()
//        {
//            return await _context.Maps.ToListAsync();
//        }

//        public async Task CreateMapAsync(Map map)
//        {
//            await _context.Maps.AddAsync(map);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateMapAsync(Map map)
//        {
//            _context.Maps.Update(map);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteMapAsync(int mapId)
//        {
//            var map = await _context.Maps.FindAsync(mapId);
//            if (map != null)
//            {
//                _context.Maps.Remove(map);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}


using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class MapRepository : IMapRepository
    {
        private readonly IMongoCollection<Map> _maps;

        public MapRepository(IMongoDatabase database)
        {
            _maps = database.GetCollection<Map>("Maps");
        }

        public async Task<Map> GetMapByIdAsync(string mapId)
        {
            return await _maps.Find(map => map.MapId == mapId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Map>> GetAllMapsAsync()
        {
            return await _maps.Find(_ => true).ToListAsync();
        }

        public async Task CreateMapAsync(Map map)
        {
            await _maps.InsertOneAsync(map);
        }

        public async Task UpdateMapAsync(Map map)
        {
            await _maps.ReplaceOneAsync(m => m.MapId == map.MapId, map);
        }

        public async Task DeleteMapAsync(string mapId)
        {
            await _maps.DeleteOneAsync(map => map.MapId == mapId);
        }
    }
}
