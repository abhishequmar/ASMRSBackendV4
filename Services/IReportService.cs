using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface IReportService
    {
        Task<Report> GetReportByIdAsync(string reportId);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task CreateReportAsync(Report report);
        Task UpdateReportAsync(Report report);
        Task DeleteReportAsync(string reportId);
    }
}
