using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public async Task<Site> GetSiteByIdAsync(string siteId)
        {
            Console.WriteLine("2 called");
            return await _siteRepository.GetSiteByIdAsync(siteId);
        }

        public async Task<IEnumerable<Site>> GetAllSitesAsync()
        {
            return await _siteRepository.GetAllSitesAsync();
        }

        public async Task CreateSiteAsync(Site site)
        {
            Console.WriteLine("craete site service called");
            await _siteRepository.CreateSiteAsync(site);
            Console.WriteLine("site service call completed");
        }

        public async Task UpdateSiteAsync(Site site)
        {
            await _siteRepository.UpdateSiteAsync(site);
        }

        public async Task DeleteSiteAsync(string siteId)
        {
            await _siteRepository.DeleteSiteAsync(siteId);
        }

        public async Task<IEnumerable<Site>> GetSiteByDiscoveredByIdAsync(string discoveredById)
        {
            return await _siteRepository.GetSiteByDiscoveredByIdAsync(discoveredById);
        }
    }
}
