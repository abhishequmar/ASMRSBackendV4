using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface ISiteService
    {
        Task<Site> GetSiteByIdAsync(string siteId);
        Task<IEnumerable<Site>> GetAllSitesAsync();
        Task CreateSiteAsync(Site site);
        Task UpdateSiteAsync(Site site);
        Task DeleteSiteAsync(string siteId);
        Task<IEnumerable<Site>> GetSiteByDiscoveredByIdAsync(string discoveredById);
    }
}
