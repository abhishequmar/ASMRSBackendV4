using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IMapService
    {
        Task<Map> GetMapByIdAsync(string mapId);
        Task<IEnumerable<Map>> GetAllMapsAsync();
        Task CreateMapAsync(Map map);
        Task UpdateMapAsync(Map map);
        Task DeleteMapAsync(string mapId);
    }
}
