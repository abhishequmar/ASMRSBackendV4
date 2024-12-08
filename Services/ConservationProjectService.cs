using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class ConservationProjectService : IConservationProjectService
    {
        private readonly IConservationProjectRepository _conservationProjectRepository;

        public ConservationProjectService(IConservationProjectRepository conservationProjectRepository)
        {
            _conservationProjectRepository = conservationProjectRepository;
        }

        public async Task<ConservationProject> GetConservationProjectByIdAsync(string projectId)
        {
            return await _conservationProjectRepository.GetConservationProjectByIdAsync(projectId);
        }

        public async Task<IEnumerable<ConservationProject>> GetAllConservationProjectsAsync()
        {
            return await _conservationProjectRepository.GetAllConservationProjectsAsync();
        }

        public async Task CreateConservationProjectAsync(ConservationProject conservationProject)
        {
            await _conservationProjectRepository.CreateConservationProjectAsync(conservationProject);
        }

        public async Task UpdateConservationProjectAsync(ConservationProject conservationProject)
        {
            await _conservationProjectRepository.UpdateConservationProjectAsync(conservationProject);
        }

        public async Task DeleteConservationProjectAsync(string projectId)
        {
            await _conservationProjectRepository.DeleteConservationProjectAsync(projectId);
        }

        public async Task<List<ConservationProject>> GetProjectsByContributorIdAsync(string contributorId)
        {
            return await _conservationProjectRepository.GetProjectsByContributorIdAsync(contributorId);
        }
    }

}
