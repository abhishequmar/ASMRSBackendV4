//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IPlatformRepository
//    {
//        Task<Platform> GetPlatformByIdAsync(int platformId);
//        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
//        Task CreatePlatformAsync(Platform platform);
//        Task UpdatePlatformAsync(Platform platform);
//        Task DeletePlatformAsync(int platformId);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IPlatformRepository
    {
        Task<Platform> GetPlatformByIdAsync(string platformId);
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task CreatePlatformAsync(Platform platform);
        Task UpdatePlatformAsync(Platform platform);
        Task DeletePlatformAsync(string platformId);
    }
}
