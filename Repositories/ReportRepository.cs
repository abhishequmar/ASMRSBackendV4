//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class ReportRepository : IReportRepository
//    {
//        private readonly AppDbContext _context;

//        public ReportRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Report> GetReportByIdAsync(int reportId)
//        {
//            return await _context.Reports.FindAsync(reportId);
//        }

//        public async Task<IEnumerable<Report>> GetAllReportsAsync()
//        {
//            return await _context.Reports.ToListAsync();
//        }

//        public async Task CreateReportAsync(Report report)
//        {
//            await _context.Reports.AddAsync(report);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateReportAsync(Report report)
//        {
//            _context.Reports.Update(report);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteReportAsync(int reportId)
//        {
//            var report = await _context.Reports.FindAsync(reportId);
//            if (report != null)
//            {
//                _context.Reports.Remove(report);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}

using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IMongoCollection<Report> _reports;

        public ReportRepository(IMongoDatabase database)
        {
            _reports = database.GetCollection<Report>("Reports");
        }

        public async Task<Report> GetReportByIdAsync(string reportId)
        {
            return await _reports.Find(r => r.ReportId == reportId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _reports.Find(_ => true).ToListAsync();
        }

        public async Task CreateReportAsync(Report report)
        {
            await _reports.InsertOneAsync(report);
        }

        public async Task UpdateReportAsync(Report report)
        {
            var filter = Builders<Report>.Filter.Eq(r => r.ReportId, report.ReportId);
            await _reports.ReplaceOneAsync(filter, report);
        }

        public async Task DeleteReportAsync(string reportId)
        {
            var filter = Builders<Report>.Filter.Eq(r => r.ReportId, reportId);
            await _reports.DeleteOneAsync(filter);
        }
    }
}
