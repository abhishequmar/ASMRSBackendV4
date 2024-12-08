using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IConservationProjectService
    {
        Task<ConservationProject> GetConservationProjectByIdAsync(string projectId);
        Task<IEnumerable<ConservationProject>> GetAllConservationProjectsAsync();
        Task CreateConservationProjectAsync(ConservationProject conservationProject);
        Task UpdateConservationProjectAsync(ConservationProject conservationProject);
        Task DeleteConservationProjectAsync(string projectId);
        Task<List<ConservationProject>> GetProjectsByContributorIdAsync(string contributorId);
    }
}
