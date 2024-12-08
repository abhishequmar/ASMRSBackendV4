using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(string id)
        {
            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] Report report)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reportService.CreateReportAsync(report);
            return CreatedAtAction(nameof(GetReportById), new { id = report.ReportId }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(string id, [FromBody] Report report)
        {
            if (id != report.ReportId)
                return BadRequest("Report ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingReport = await _reportService.GetReportByIdAsync(id);
            if (existingReport == null)
                return NotFound();

            await _reportService.UpdateReportAsync(report);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(string id)
        {
            var existingReport = await _reportService.GetReportByIdAsync(id);
            if (existingReport == null)
                return NotFound();

            await _reportService.DeleteReportAsync(id);
            return NoContent();
        }
    }
}
