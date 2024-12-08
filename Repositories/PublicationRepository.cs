//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class PublicationRepository : IPublicationRepository
//    {
//        private readonly AppDbContext _context;

//        public PublicationRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Publication> GetPublicationByIdAsync(int publicationId)
//        {
//            return await _context.Publications.FindAsync(publicationId);
//        }

//        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
//        {
//            return await _context.Publications.ToListAsync();
//        }

//        public async Task CreatePublicationAsync(Publication publication)
//        {
//            await _context.Publications.AddAsync(publication);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdatePublicationAsync(Publication publication)
//        {
//            _context.Publications.Update(publication);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeletePublicationAsync(int publicationId)
//        {
//            var publication = await _context.Publications.FindAsync(publicationId);
//            if (publication != null)
//            {
//                _context.Publications.Remove(publication);
//                await _context.SaveChangesAsync();
//            }
//        }
//        public async Task<IEnumerable<Publication>> GetPublicationsBySiteIdAsync(int siteId)
//        {
//            return await _context.Publications.Where(p => p.SiteId == siteId).ToListAsync();
//        }

//        public async Task<List<Publication>> GetPublicationsByAuthorIdAsync(int authorId)
//        {
//            return await _context.Set<Publication>()
//                                 .Where(p => p.AuthorId == authorId)
//                                 .ToListAsync();
//        }

//    }
//}


using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly IMongoCollection<Publication> _publications;

        public PublicationRepository(IMongoDatabase database)
        {
            _publications = database.GetCollection<Publication>("Publications");
        }

        public async Task<Publication> GetPublicationByIdAsync(string publicationId)
        {
            return await _publications.Find(p => p.PublicationId == publicationId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
        {
            return await _publications.Find(_ => true).ToListAsync();
        }

        public async Task CreatePublicationAsync(Publication publication)
        {
            await _publications.InsertOneAsync(publication);
        }

        public async Task UpdatePublicationAsync(Publication publication)
        {
            await _publications.ReplaceOneAsync(p => p.PublicationId == publication.PublicationId, publication);
        }

        public async Task DeletePublicationAsync(string publicationId)
        {
            await _publications.DeleteOneAsync(p => p.PublicationId == publicationId);
        }

        public async Task<IEnumerable<Publication>> GetPublicationsBySiteIdAsync(string siteId)
        {
            return await _publications.Find(p => p.SiteId == siteId).ToListAsync();
        }

        public async Task<List<Publication>> GetPublicationsByAuthorIdAsync(string authorId)
        {
            return await _publications.Find(p => p.AuthorId == authorId).ToListAsync();
        }
    }
}
