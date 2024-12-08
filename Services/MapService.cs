using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;

        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public async Task<Map> GetMapByIdAsync(string mapId)
        {
            return await _mapRepository.GetMapByIdAsync(mapId);
        }

        public async Task<IEnumerable<Map>> GetAllMapsAsync()
        {
            return await _mapRepository.GetAllMapsAsync();
        }

        public async Task CreateMapAsync(Map map)
        {
            await _mapRepository.CreateMapAsync(map);
        }

        public async Task UpdateMapAsync(Map map)
        {
            await _mapRepository.UpdateMapAsync(map);
        }

        public async Task DeleteMapAsync(string mapId)
        {
            await _mapRepository.DeleteMapAsync(mapId);
        }
    }
}
