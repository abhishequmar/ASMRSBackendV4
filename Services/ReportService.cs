using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Report> GetReportByIdAsync(string reportId)
        {
            return await _reportRepository.GetReportByIdAsync(reportId);
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _reportRepository.GetAllReportsAsync();
        }

        public async Task CreateReportAsync(Report report)
        {
            await _reportRepository.CreateReportAsync(report);
        }

        public async Task UpdateReportAsync(Report report)
        {
            await _reportRepository.UpdateReportAsync(report);
        }

        public async Task DeleteReportAsync(string reportId)
        {
            await _reportRepository.DeleteReportAsync(reportId);
        }
    }
}
