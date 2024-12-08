//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IArtifactTrackingRepository
//    {
//        Task<ArtifactTracking> GetArtifactTrackingByIdAsync(int trackingId);
//        Task<IEnumerable<ArtifactTracking>> GetAllArtifactTrackingsAsync();
//        Task CreateArtifactTrackingAsync(ArtifactTracking artifactTracking);
//        Task UpdateArtifactTrackingAsync(ArtifactTracking artifactTracking);
//        Task DeleteArtifactTrackingAsync(int trackingId);
//    }
//}


using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IArtifactTrackingRepository
    {
        Task<ArtifactTracking> GetArtifactTrackingByIdAsync(string trackingId);
        Task<IEnumerable<ArtifactTracking>> GetAllArtifactTrackingsAsync();
        Task CreateArtifactTrackingAsync(ArtifactTracking artifactTracking);
        Task UpdateArtifactTrackingAsync(ArtifactTracking artifactTracking);
        Task DeleteArtifactTrackingAsync(string trackingId);
    }
}
