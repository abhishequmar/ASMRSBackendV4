//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IConservationProjectRepository
//    {
//        Task<ConservationProject> GetConservationProjectByIdAsync(int projectId);
//        Task<IEnumerable<ConservationProject>> GetAllConservationProjectsAsync();
//        Task CreateConservationProjectAsync(ConservationProject conservationProject);
//        Task UpdateConservationProjectAsync(ConservationProject conservationProject);
//        Task DeleteConservationProjectAsync(int projectId);
//        Task<List<ConservationProject>> GetProjectsByContributorIdAsync(int contributorId);
//    }

//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IConservationProjectRepository
    {
        Task<ConservationProject> GetConservationProjectByIdAsync(string projectId);
        Task<IEnumerable<ConservationProject>> GetAllConservationProjectsAsync();
        Task CreateConservationProjectAsync(ConservationProject conservationProject);
        Task UpdateConservationProjectAsync(ConservationProject conservationProject);
        Task DeleteConservationProjectAsync(string projectId);
        Task<List<ConservationProject>> GetProjectsByContributorIdAsync(string contributorId);
    }
}
