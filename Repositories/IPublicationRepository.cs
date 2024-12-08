//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IPublicationRepository
//    {
//        Task<Publication> GetPublicationByIdAsync(int publicationId);
//        Task<IEnumerable<Publication>> GetAllPublicationsAsync();
//        Task CreatePublicationAsync(Publication publication);
//        Task UpdatePublicationAsync(Publication publication);
//        Task DeletePublicationAsync(int publicationId);
//        Task<IEnumerable<Publication>> GetPublicationsBySiteIdAsync(int siteId);
//        Task<List<Publication>> GetPublicationsByAuthorIdAsync(int authorId);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IPublicationRepository
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
