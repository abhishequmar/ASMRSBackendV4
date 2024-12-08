using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtifactsController : ControllerBase
    {
        private readonly IArtifactService _artifactService;

        public ArtifactsController(IArtifactService artifactService)
        {
            _artifactService = artifactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtifacts()
        {
            var artifacts = await _artifactService.GetAllArtifactsAsync();
            return Ok(artifacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtifactById(string id)
        {
            var artifact = await _artifactService.GetArtifactByIdAsync(id);
            if (artifact == null)
                return NotFound();

            return Ok(artifact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtifact([FromBody] Artifact artifact)
        {
            artifact.ArtifactId = Guid.NewGuid().ToString();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await _artifactService.CreateArtifactAsync(artifact);
            return CreatedAtAction(nameof(GetArtifactById), new { id = artifact.ArtifactId }, artifact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtifact(string id, [FromBody] Artifact artifact)
        {
            if (id != artifact.ArtifactId)
                return BadRequest("Artifact ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingArtifact = await _artifactService.GetArtifactByIdAsync(id);
            if (existingArtifact == null)
                return NotFound();

            await _artifactService.UpdateArtifactAsync(artifact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtifact(string id)
        {
            var existingArtifact = await _artifactService.GetArtifactByIdAsync(id);
            if (existingArtifact == null)
                return NotFound();

            await _artifactService.DeleteArtifactAsync(id);
            return NoContent();
        }

        [HttpGet("site/{siteId}")]
        public async Task<ActionResult<IEnumerable<Artifact>>> GetArtifactsBySiteIdAsync(string siteId)
        {
            var artifacts = await _artifactService.GetArtifactsBySiteIdAsync(siteId);
            if (artifacts == null || !artifacts.Any())
            {
                return NotFound();
            }
            return Ok(artifacts);
        }
        [HttpGet("discoveredBy/{discoveredById}")]
        public async Task<ActionResult<IEnumerable<Artifact>>> GetArtifactsByDiscoveredById(string discoveredById)
        {
            var artifacts = await _artifactService.GetArtifactsByDiscoveredByIdAsync(discoveredById);
            if (artifacts == null || !artifacts.Any())
            {
                return NotFound($"No artifacts found for discoveredById {discoveredById}.");
            }
            return Ok(artifacts);
        }
    }
}
