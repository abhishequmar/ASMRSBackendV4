
//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IArtifactRepository
//    {
//        Task<Artifact> GetArtifactByIdAsync(int artifactId);
//        Task<IEnumerable<Artifact>> GetAllArtifactsAsync();
//        Task CreateArtifactAsync(Artifact artifact);
//        Task UpdateArtifactAsync(Artifact artifact);
//        Task DeleteArtifactAsync(int artifactId);
//        Task<IEnumerable<Artifact>> GetArtifactsBySiteIdAsync(int siteId);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IArtifactRepository
    {
        Task<Artifact> GetArtifactByIdAsync(string artifactId);
        Task<IEnumerable<Artifact>> GetAllArtifactsAsync();
        Task CreateArtifactAsync(Artifact artifact);
        Task UpdateArtifactAsync(Artifact artifact);
        Task DeleteArtifactAsync(string artifactId);
        Task<IEnumerable<Artifact>> GetArtifactsBySiteIdAsync(string siteId);
        Task<IEnumerable<Artifact>> GetArtifactsByDiscoveredByIdAsync(string discoveredById);
    }
}
