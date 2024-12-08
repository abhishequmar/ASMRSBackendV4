using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcavationsController : ControllerBase
    {
        private readonly IExcavationService _excavationService;

        public ExcavationsController(IExcavationService excavationService)
        {
            _excavationService = excavationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExcavations()
        {
            var excavations = await _excavationService.GetAllExcavationsAsync();
            return Ok(excavations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExcavationById(string id)
        {
            var excavation = await _excavationService.GetExcavationByIdAsync(id);
            if (excavation == null)
                return NotFound();

            return Ok(excavation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcavation([FromBody] Excavation excavation)
        {
            excavation.ExcavationId = Guid.NewGuid().ToString();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _excavationService.CreateExcavationAsync(excavation);
            return CreatedAtAction(nameof(GetExcavationById), new { id = excavation.ExcavationId }, excavation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExcavation(string id, [FromBody] Excavation excavation)
        {
            if (id != excavation.ExcavationId)
                return BadRequest("Excavation ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingExcavation = await _excavationService.GetExcavationByIdAsync(id);
            if (existingExcavation == null)
                return NotFound();

            await _excavationService.UpdateExcavationAsync(excavation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcavation(string id)
        {
            var existingExcavation = await _excavationService.GetExcavationByIdAsync(id);
            if (existingExcavation == null)
                return NotFound();

            await _excavationService.DeleteExcavationAsync(id);
            return NoContent();
        }

        [HttpGet("by-lead-archaeologist/{leadArchaeologistId}")]
        public async Task<IActionResult> GetExcavationsByLeadArchaeologist(string leadArchaeologistId)
        {
            if (string.IsNullOrWhiteSpace(leadArchaeologistId))
                return BadRequest("Lead Archaeologist ID is required.");

            var excavations = await _excavationService.GetExcavationsByLeadArchaeologistAsync(leadArchaeologistId);

            if (excavations == null || !excavations.Any())
                return NotFound($"No excavations found for Lead Archaeologist ID: {leadArchaeologistId}");

            return Ok(excavations);
        }

    }
}
