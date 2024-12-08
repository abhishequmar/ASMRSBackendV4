using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IPlatformService
    {
        Task<Platform> GetPlatformByIdAsync(string platformId);
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task CreatePlatformAsync(Platform platform);
        Task UpdatePlatformAsync(Platform platform);
        Task DeletePlatformAsync(string platformId);
    }
}
