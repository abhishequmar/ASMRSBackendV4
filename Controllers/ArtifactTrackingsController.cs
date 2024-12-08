using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtifactTrackingsController : ControllerBase
    {
        private readonly IArtifactTrackingService _artifactTrackingService;

        public ArtifactTrackingsController(IArtifactTrackingService artifactTrackingService)
        {
            _artifactTrackingService = artifactTrackingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtifactTrackings()
        {
            var trackings = await _artifactTrackingService.GetAllArtifactTrackingsAsync();
            return Ok(trackings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtifactTrackingById(string id)
        {
            var tracking = await _artifactTrackingService.GetArtifactTrackingByIdAsync(id);
            if (tracking == null)
                return NotFound();

            return Ok(tracking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtifactTracking([FromBody] ArtifactTracking artifactTracking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _artifactTrackingService.CreateArtifactTrackingAsync(artifactTracking);
            return CreatedAtAction(nameof(GetArtifactTrackingById), new { id = artifactTracking.TrackingId }, artifactTracking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtifactTracking(string id, [FromBody] ArtifactTracking artifactTracking)
        {
            if (id != artifactTracking.TrackingId)
                return BadRequest("Tracking ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTracking = await _artifactTrackingService.GetArtifactTrackingByIdAsync(id);
            if (existingTracking == null)
                return NotFound();

            await _artifactTrackingService.UpdateArtifactTrackingAsync(artifactTracking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtifactTracking(string id)
        {
            var existingTracking = await _artifactTrackingService.GetArtifactTrackingByIdAsync(id);
            if (existingTracking == null)
                return NotFound();

            await _artifactTrackingService.DeleteArtifactTrackingAsync(id);
            return NoContent();
        }
    }
}
