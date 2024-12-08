using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class VisitorTourService : IVisitorTourService
    {
        private readonly IVisitorTourRepository _visitorTourRepository;
        private readonly IEmailService _mailService;

        public VisitorTourService(IVisitorTourRepository visitorTourRepository, IEmailService mailService)
        {
            _visitorTourRepository = visitorTourRepository;
            _mailService = mailService;
        }

        public async Task<VisitorTour> GetVisitorTourByIdAsync(string tourId)
        {
            return await _visitorTourRepository.GetVisitorTourByIdAsync(tourId);
        }

        public async Task<IEnumerable<VisitorTour>> GetAllVisitorToursAsync()
        {
            return await _visitorTourRepository.GetAllVisitorToursAsync();
        }

        public async Task CreateVisitorTourAsync(VisitorTour visitorTour)
        {
            await _visitorTourRepository.CreateVisitorTourAsync(visitorTour);
        }

        public async Task UpdateVisitorTourAsync(VisitorTour visitorTour)
        {
            await _visitorTourRepository.UpdateVisitorTourAsync(visitorTour);
        }

        public async Task DeleteVisitorTourAsync(string tourId)
        {
            await _visitorTourRepository.DeleteVisitorTourAsync(tourId);
        }

        public async Task<string> JoinTourAsync(VisitorTour tour, string userEmail)
        {
            Console.WriteLine("join tour service hit//////////////////////////");
            string bookingDetails = $"<p>Dear Sir/Ma'am,</p><p>Thank you for choosing our tour service. We are excited to confirm your booking. Below are the details of your reservation:</p><h3>--- Booking Details ---</h3><p><strong>Tour Site Name:</strong> {tour.SiteName} | <strong>Tour Description:</strong> {tour.Description} | <strong>Tour Time:</strong> {tour.Time} | <strong>Duration:</strong> {tour.Duration} | <strong>Booking Status:</strong> {tour.BookingStatus}</p><h3>--- Visitor Details ---</h3><p><strong>Visitor ID:</strong> {userEmail}</p><p>If you have any questions or need assistance, please contact our support team at <a href='mailto:support@tours.com'>support@tours.com</a> or call +1 (800) 555-1234.</p><p>We look forward to serving you.</p><p>Best regards,</p><p>The Tour Service Team</p><p>TourService Inc. | <a href='http://www.tours.com'>www.tours.com</a> | Support: <a href='mailto:support@tours.com'>support@tours.com</a> | Phone: +1 (800) 555-1234</p>";

            // Send the confirmation email
            await _mailService.SendEmailAsync(userEmail, "Booking Confirmation", bookingDetails);

            return "You have successfully joined the tour.";
        }

        public async Task<IEnumerable<VisitorTour>> GetVisitorToursByVisitorIdAsync(string visitorId)
        {
            return await _visitorTourRepository.GetVisitorToursByVisitorIdAsync(visitorId);
        }

        // Get all VisitorTours by TourGuideId
        public async Task<IEnumerable<VisitorTour>> GetVisitorToursByTourGuideIdAsync(string tourGuideId)
        {
            return await _visitorTourRepository.GetVisitorToursByTourGuideIdAsync(tourGuideId);
        }
    }
}
