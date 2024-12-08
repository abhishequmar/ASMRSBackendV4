//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class SiteRepository : ISiteRepository
//    {
//        private readonly AppDbContext _context;

//        public SiteRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Site> GetSiteByIdAsync(int siteId)
//        {
//            return await _context.Sites.FindAsync(siteId);
//        }

//        public async Task<IEnumerable<Site>> GetAllSitesAsync()
//        {
//            return await _context.Sites.ToListAsync();
//        }

//        public async Task CreateSiteAsync(Site site)
//        {
//            await _context.Sites.AddAsync(site);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateSiteAsync(Site site)
//        {
//            _context.Sites.Update(site);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteSiteAsync(int siteId)
//        {
//            var site = await _context.Sites.FindAsync(siteId);
//            if (site != null)
//            {
//                _context.Sites.Remove(site);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<Site>> GetSiteByDiscoveredByIdAsync(int discoveredById)
//        {
//            return await _context.Sites
//                                 .Where(s => s.DiscoveredBy == discoveredById)
//                                 .ToListAsync();
//        }


//    }
//}


using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly IMongoCollection<Site> _sites;

        public SiteRepository(IMongoDatabase database)
        {
            _sites = database.GetCollection<Site>("Sites");
        }

        public async Task<Site> GetSiteByIdAsync(string siteId)
        {
            Console.WriteLine("3 called");
            return await _sites.Find(s => s.SiteId == siteId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Site>> GetAllSitesAsync()
        {
            return await _sites.Find(_ => true).ToListAsync();
        }

        public async Task CreateSiteAsync(Site site)
        {
            Console.WriteLine("///////////////////////////site repo called");
            await _sites.InsertOneAsync(site);
            Console.WriteLine("site repo call completed");
        }

        public async Task UpdateSiteAsync(Site site)
        {
            var updateDefinition = Builders<Site>.Update
            .Set(s => s.Name, site.Name)
            .Set(s => s.Location, site.Location)
            .Set(s => s.HistoricalPeriod, site.HistoricalPeriod)
            .Set(s => s.Description, site.Description)
            .Set(s => s.DiscoveredById, site.DiscoveredById)
            .Set(s => s.ConservationStatus, site.ConservationStatus)
            .Set(s => s.DateDiscovered, site.DateDiscovered)
            .Set(s => s.ImageUrl, site.ImageUrl);

        await _sites.UpdateOneAsync(s => s.SiteId == site.SiteId, updateDefinition);
        }

        public async Task DeleteSiteAsync(string siteId)
        {
            await _sites.DeleteOneAsync(s => s.SiteId == siteId);
        }

        public async Task<IEnumerable<Site>> GetSiteByDiscoveredByIdAsync(string discoveredById)
        {
            return await _sites.Find(s => s.DiscoveredById == discoveredById).ToListAsync();
        }
    }
}
