using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class ArtifactService : IArtifactService
    {
        private readonly IArtifactRepository _artifactRepository;

        public ArtifactService(IArtifactRepository artifactRepository)
        {
            _artifactRepository = artifactRepository;
        }

        public async Task<Artifact> GetArtifactByIdAsync(string artifactId)
        {
            return await _artifactRepository.GetArtifactByIdAsync(artifactId);
        }

        public async Task<IEnumerable<Artifact>> GetAllArtifactsAsync()
        {
            return await _artifactRepository.GetAllArtifactsAsync();
        }

        public async Task CreateArtifactAsync(Artifact artifact)
        {
            await _artifactRepository.CreateArtifactAsync(artifact);
        }

        public async Task UpdateArtifactAsync(Artifact artifact)
        {
            await _artifactRepository.UpdateArtifactAsync(artifact);
        }

        public async Task DeleteArtifactAsync(string artifactId)
        {
            await _artifactRepository.DeleteArtifactAsync(artifactId);
        }

        public async Task<IEnumerable<Artifact>> GetArtifactsBySiteIdAsync(string siteId)
        {
            return await _artifactRepository.GetArtifactsBySiteIdAsync(siteId);
        }

        public async Task<IEnumerable<Artifact>> GetArtifactsByDiscoveredByIdAsync(string discoveredById)
        {
            return await _artifactRepository.GetArtifactsByDiscoveredByIdAsync(discoveredById);
        }

    }
}
