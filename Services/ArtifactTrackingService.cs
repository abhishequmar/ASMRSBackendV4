using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class ArtifactTrackingService : IArtifactTrackingService
    {
        private readonly IArtifactTrackingRepository _artifactTrackingRepository;

        public ArtifactTrackingService(IArtifactTrackingRepository artifactTrackingRepository)
        {
            _artifactTrackingRepository = artifactTrackingRepository;
        }

        public async Task<ArtifactTracking> GetArtifactTrackingByIdAsync(string trackingId)
        {
            return await _artifactTrackingRepository.GetArtifactTrackingByIdAsync(trackingId);
        }

        public async Task<IEnumerable<ArtifactTracking>> GetAllArtifactTrackingsAsync()
        {
            return await _artifactTrackingRepository.GetAllArtifactTrackingsAsync();
        }

        public async Task CreateArtifactTrackingAsync(ArtifactTracking artifactTracking)
        {
            await _artifactTrackingRepository.CreateArtifactTrackingAsync(artifactTracking);
        }

        public async Task UpdateArtifactTrackingAsync(ArtifactTracking artifactTracking)
        {
            await _artifactTrackingRepository.UpdateArtifactTrackingAsync(artifactTracking);
        }

        public async Task DeleteArtifactTrackingAsync(string trackingId)
        {
            await _artifactTrackingRepository.DeleteArtifactTrackingAsync(trackingId);
        }
    }
}
