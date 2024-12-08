//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface ISiteRepository
//    {
//        Task<Site> GetSiteByIdAsync(int siteId);
//        Task<IEnumerable<Site>> GetAllSitesAsync();
//        Task CreateSiteAsync(Site site);
//        Task UpdateSiteAsync(Site site);
//        Task DeleteSiteAsync(int siteId);

//        Task<IEnumerable<Site>> GetSiteByDiscoveredByIdAsync(int discoveredById);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface ISiteRepository
    {
        Task<Site> GetSiteByIdAsync(string siteId);
        Task<IEnumerable<Site>> GetAllSitesAsync();
        Task CreateSiteAsync(Site site);
        Task UpdateSiteAsync(Site site);
        Task DeleteSiteAsync(string siteId);
        Task<IEnumerable<Site>> GetSiteByDiscoveredByIdAsync(string discoveredById);
    }
}
