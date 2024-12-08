//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class ArtifactTrackingRepository : IArtifactTrackingRepository
//    {
//        private readonly AppDbContext _context;

//        public ArtifactTrackingRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<ArtifactTracking> GetArtifactTrackingByIdAsync(int trackingId)
//        {
//            return await _context.ArtifactTrackings.FindAsync(trackingId);
//        }

//        public async Task<IEnumerable<ArtifactTracking>> GetAllArtifactTrackingsAsync()
//        {
//            return await _context.ArtifactTrackings.ToListAsync();
//        }

//        public async Task CreateArtifactTrackingAsync(ArtifactTracking artifactTracking)
//        {
//            await _context.ArtifactTrackings.AddAsync(artifactTracking);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateArtifactTrackingAsync(ArtifactTracking artifactTracking)
//        {
//            _context.ArtifactTrackings.Update(artifactTracking);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteArtifactTrackingAsync(int trackingId)
//        {
//            var artifactTracking = await _context.ArtifactTrackings.FindAsync(trackingId);
//            if (artifactTracking != null)
//            {
//                _context.ArtifactTrackings.Remove(artifactTracking);
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
    public class ArtifactTrackingRepository : IArtifactTrackingRepository
    {
        private readonly IMongoCollection<ArtifactTracking> _artifactTrackings;

        public ArtifactTrackingRepository(AppDbContext context)
        {
            _artifactTrackings = context.ArtifactTrackings;
        }

        public async Task<ArtifactTracking> GetArtifactTrackingByIdAsync(string trackingId)
        {
            return await _artifactTrackings.Find(at => at.TrackingId == trackingId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ArtifactTracking>> GetAllArtifactTrackingsAsync()
        {
            return await _artifactTrackings.Find(_ => true).ToListAsync();
        }

        public async Task CreateArtifactTrackingAsync(ArtifactTracking artifactTracking)
        {
            await _artifactTrackings.InsertOneAsync(artifactTracking);
        }

        public async Task UpdateArtifactTrackingAsync(ArtifactTracking artifactTracking)
        {
            await _artifactTrackings.ReplaceOneAsync(at => at.TrackingId == artifactTracking.TrackingId, artifactTracking);
        }

        public async Task DeleteArtifactTrackingAsync(string trackingId)
        {
            await _artifactTrackings.DeleteOneAsync(at => at.TrackingId == trackingId);
        }
    }
}
