using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IArtifactTrackingService
    {
        Task<ArtifactTracking> GetArtifactTrackingByIdAsync(string trackingId);
        Task<IEnumerable<ArtifactTracking>> GetAllArtifactTrackingsAsync();
        Task CreateArtifactTrackingAsync(ArtifactTracking artifactTracking);
        Task UpdateArtifactTrackingAsync(ArtifactTracking artifactTracking);
        Task DeleteArtifactTrackingAsync(string trackingId);
    }
}
