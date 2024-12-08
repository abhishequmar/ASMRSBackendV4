//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IVisitorTourRepository
//    {
//        Task<VisitorTour> GetVisitorTourByIdAsync(int tourId);
//        Task<IEnumerable<VisitorTour>> GetAllVisitorToursAsync();
//        Task CreateVisitorTourAsync(VisitorTour visitorTour);
//        Task UpdateVisitorTourAsync(VisitorTour visitorTour);
//        Task DeleteVisitorTourAsync(int tourId);
//        Task SaveChangesAsync(VisitorTour visitorTour);
//        Task<IEnumerable<VisitorTour>> GetVisitorToursByVisitorIdAsync(int visitorId);
//        Task<IEnumerable<VisitorTour>> GetVisitorToursByTourGuideIdAsync(int tourGuideId);
//    }
//}


using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IVisitorTourRepository
    {
        Task<VisitorTour> GetVisitorTourByIdAsync(string tourId);
        Task<IEnumerable<VisitorTour>> GetAllVisitorToursAsync();
        Task CreateVisitorTourAsync(VisitorTour visitorTour);
        Task UpdateVisitorTourAsync(VisitorTour visitorTour);
        Task DeleteVisitorTourAsync(string tourId);
        Task SaveChangesAsync(VisitorTour visitorTour);
        Task<IEnumerable<VisitorTour>> GetVisitorToursByVisitorIdAsync(string visitorId);
        Task<IEnumerable<VisitorTour>> GetVisitorToursByTourGuideIdAsync(string tourGuideId);
    }
}
