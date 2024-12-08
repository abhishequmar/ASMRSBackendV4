using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;

        public PublicationService(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<Publication> GetPublicationByIdAsync(string publicationId)
        {
            return await _publicationRepository.GetPublicationByIdAsync(publicationId);
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
        {
            return await _publicationRepository.GetAllPublicationsAsync();
        }

        public async Task CreatePublicationAsync(Publication publication)
        {
            await _publicationRepository.CreatePublicationAsync(publication);
        }

        public async Task UpdatePublicationAsync(Publication publication)
        {
            await _publicationRepository.UpdatePublicationAsync(publication);
        }

        public async Task DeletePublicationAsync(string publicationId)
        {
            await _publicationRepository.DeletePublicationAsync(publicationId);
        }

        public async Task<IEnumerable<Publication>> GetPublicationsBySiteIdAsync(string siteId)
        {
            return await _publicationRepository.GetPublicationsBySiteIdAsync(siteId);
        }

        public async Task<List<Publication>> GetPublicationsByAuthorIdAsync(string authorId)
        {
            return await _publicationRepository.GetPublicationsByAuthorIdAsync(authorId);
        }
    }
}
