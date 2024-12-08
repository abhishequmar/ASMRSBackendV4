//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface IReportRepository
//    {
//        Task<Report> GetReportByIdAsync(int reportId);
//        Task<IEnumerable<Report>> GetAllReportsAsync();
//        Task CreateReportAsync(Report report);
//        Task UpdateReportAsync(Report report);
//        Task DeleteReportAsync(int reportId);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface IReportRepository
    {
        Task<Report> GetReportByIdAsync(string reportId);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task CreateReportAsync(Report report);
        Task UpdateReportAsync(Report report);
        Task DeleteReportAsync(string reportId);
    }
}
