using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IVisitorTourService
    {
        Task<VisitorTour> GetVisitorTourByIdAsync(string tourId);
        Task<IEnumerable<VisitorTour>> GetAllVisitorToursAsync();
        Task CreateVisitorTourAsync(VisitorTour visitorTour);
        Task UpdateVisitorTourAsync(VisitorTour visitorTour);
        Task DeleteVisitorTourAsync(string tourId);
        Task<string> JoinTourAsync(VisitorTour tour, string userEmail);
        Task<IEnumerable<VisitorTour>> GetVisitorToursByVisitorIdAsync(string visitorId);
        Task<IEnumerable<VisitorTour>> GetVisitorToursByTourGuideIdAsync(string tourGuideId);

    }
}
