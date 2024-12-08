using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IPublicationService
    {
        Task<Publication> GetPublicationByIdAsync(string publicationId);
        Task<IEnumerable<Publication>> GetAllPublicationsAsync();
        Task CreatePublicationAsync(Publication publication);
        Task UpdatePublicationAsync(Publication publication);
        Task DeletePublicationAsync(string publicationId);
        Task<IEnumerable<Publication>> GetPublicationsBySiteIdAsync(string siteId);
        Task<List<Publication>> GetPublicationsByAuthorIdAsync(string authorId);
    }
}
