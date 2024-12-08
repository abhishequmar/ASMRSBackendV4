//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class ExcavationRepository : IExcavationRepository
//    {
//        private readonly AppDbContext _context;

//        public ExcavationRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Excavation> GetExcavationByIdAsync(int excavationId)
//        {
//            return await _context.Excavations.FindAsync(excavationId);
//        }

//        public async Task<IEnumerable<Excavation>> GetAllExcavationsAsync()
//        {
//            return await _context.Excavations.ToListAsync();
//        }

//        public async Task CreateExcavationAsync(Excavation excavation)
//        {
//            await _context.Excavations.AddAsync(excavation);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateExcavationAsync(Excavation excavation)
//        {
//            _context.Excavations.Update(excavation);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteExcavationAsync(int excavationId)
//        {
//            var excavation = await _context.Excavations.FindAsync(excavationId);
//            if (excavation != null)
//            {
//                _context.Excavations.Remove(excavation);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}


using AsmrsBackend.Data;
using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class ExcavationRepository : IExcavationRepository
    {
        private readonly IMongoCollection<Excavation> _excavations;

        public ExcavationRepository(AppDbContext context)
        {
            _excavations = context.Excavations;
        }

        public async Task<Excavation> GetExcavationByIdAsync(string excavationId)
        {
            return await _excavations.Find(e => e.ExcavationId == excavationId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Excavation>> GetAllExcavationsAsync()
        {
            return await _excavations.Find(_ => true).ToListAsync();
        }

        public async Task CreateExcavationAsync(Excavation excavation)
        {
            await _excavations.InsertOneAsync(excavation);
        }

        public async Task UpdateExcavationAsync(Excavation excavation)
{
    var updateDefinition = Builders<Excavation>.Update
        .Set(e => e.SiteId, excavation.SiteId)
        .Set(e => e.SiteName, excavation.SiteName)
        .Set(e => e.Title, excavation.Title)
        .Set(e => e.StartDate, excavation.StartDate)
        .Set(e => e.EndDate, excavation.EndDate)
        
        .Set(e => e.Status, excavation.Status)
        .Set(e => e.TeamMembers, excavation.TeamMembers);

    // Update the excavation document with the specified ExcavationId
    await _excavations.UpdateOneAsync(e => e.ExcavationId == excavation.ExcavationId, updateDefinition);
}

        public async Task DeleteExcavationAsync(string excavationId)
        {
            await _excavations.DeleteOneAsync(e => e.ExcavationId == excavationId);
        }

        public async Task<IEnumerable<Excavation>> GetExcavationsByLeadArchaeologistAsync(string leadArchaeologistId)
    {
        // MongoDB query to find all excavations by a specific lead archaeologist
        return await _excavations
            .Find(e => e.LeadArchaeologistId == leadArchaeologistId)
            .ToListAsync();
    }
    }
}
