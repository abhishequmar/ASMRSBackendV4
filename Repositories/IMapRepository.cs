//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IMapRepository
//    {
//        Task<Map> GetMapByIdAsync(int mapId);
//        Task<IEnumerable<Map>> GetAllMapsAsync();
//        Task CreateMapAsync(Map map);
//        Task UpdateMapAsync(Map map);
//        Task DeleteMapAsync(int mapId);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IMapRepository
    {
        Task<Map> GetMapByIdAsync(string mapId);
        Task<IEnumerable<Map>> GetAllMapsAsync();
        Task CreateMapAsync(Map map);
        Task UpdateMapAsync(Map map);
        Task DeleteMapAsync(string mapId);
    }
}
