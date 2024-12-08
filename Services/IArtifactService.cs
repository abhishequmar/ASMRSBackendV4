using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IArtifactService
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
