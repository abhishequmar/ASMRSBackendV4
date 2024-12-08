using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public async Task<Platform> GetPlatformByIdAsync(string platformId)
        {
            return await _platformRepository.GetPlatformByIdAsync(platformId);
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await _platformRepository.GetAllPlatformsAsync();
        }

        public async Task CreatePlatformAsync(Platform platform)
        {
            await _platformRepository.CreatePlatformAsync(platform);
        }

        public async Task UpdatePlatformAsync(Platform platform)
        {
            await _platformRepository.UpdatePlatformAsync(platform);
        }

        public async Task DeletePlatformAsync(string platformId)
        {
            await _platformRepository.DeletePlatformAsync(platformId);
        }
    }
}
