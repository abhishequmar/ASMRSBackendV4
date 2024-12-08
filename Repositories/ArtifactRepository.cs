//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class ArtifactRepository : IArtifactRepository
//    {
//        private readonly AppDbContext _context;

//        public ArtifactRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Artifact> GetArtifactByIdAsync(int artifactId)
//        {
//            return await _context.Artifacts.FindAsync(artifactId);
//        }

//        public async Task<IEnumerable<Artifact>> GetAllArtifactsAsync()
//        {
//            return await _context.Artifacts.ToListAsync();
//        }

//        public async Task CreateArtifactAsync(Artifact artifact)
//        {
//            await _context.Artifacts.AddAsync(artifact);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateArtifactAsync(Artifact artifact)
//        {
//            _context.Artifacts.Update(artifact);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteArtifactAsync(int artifactId)
//        {
//            var artifact = await _context.Artifacts.FindAsync(artifactId);
//            if (artifact != null)
//            {
//                _context.Artifacts.Remove(artifact);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<Artifact>> GetArtifactsBySiteIdAsync(int siteId)
//        {
//            return await _context.Artifacts.Where(a => a.SiteId == siteId).ToListAsync();
//        }

//    }


//}


using AsmrsBackend.Data;
using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class ArtifactRepository : IArtifactRepository
    {
        private readonly IMongoCollection<Artifact> _artifacts;
        

        public ArtifactRepository(AppDbContext context)
        {
            _artifacts = context.Artifacts;
        }

        public async Task<Artifact> GetArtifactByIdAsync(string artifactId)
        {
            return await _artifacts.Find(a => a.ArtifactId == artifactId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Artifact>> GetAllArtifactsAsync()
        {
            return await _artifacts.Find(_ => true).ToListAsync();
        }

        public async Task CreateArtifactAsync(Artifact artifact)
        {
            await _artifacts.InsertOneAsync(artifact);
        }

        public async Task UpdateArtifactAsync(Artifact artifact)
{
    var updateDefinition = Builders<Artifact>.Update
        .Set(a => a.SiteId, artifact.SiteId)
        .Set(a => a.DiscoveredById, artifact.DiscoveredById)
        .Set(a => a.Name, artifact.Name)
        .Set(a => a.Material, artifact.Material)
        .Set(a => a.Condition, artifact.Condition)
        .Set(a => a.CulturalSignificance, artifact.CulturalSignificance)
        .Set(a => a.DateFound, artifact.DateFound)
        .Set(a => a.PreservationStatus, artifact.PreservationStatus);

    // Use ReplaceOneAsync to apply updates
    await _artifacts.UpdateOneAsync(
        a => a.ArtifactId == artifact.ArtifactId, // Filter by ArtifactId
        updateDefinition // Update the relevant fields
    );
}


        public async Task DeleteArtifactAsync(string artifactId)
        {
            await _artifacts.DeleteOneAsync(a => a.ArtifactId == artifactId);
        }

        public async Task<IEnumerable<Artifact>> GetArtifactsBySiteIdAsync(string siteId)
        {
            return await _artifacts.Find(a => a.SiteId == siteId).ToListAsync();
        }

        public async Task<IEnumerable<Artifact>> GetArtifactsByDiscoveredByIdAsync(string discoveredById)
        {
            return await _artifacts
                .Find(a => a.DiscoveredById == discoveredById)
                .ToListAsync();
        }
    }
}
