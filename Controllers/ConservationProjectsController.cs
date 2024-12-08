using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConservationProjectsController : ControllerBase
    {
        private readonly IConservationProjectService _conservationProjectService;

        public ConservationProjectsController(IConservationProjectService conservationProjectService)
        {
            _conservationProjectService = conservationProjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConservationProjects()
        {
            var projects = await _conservationProjectService.GetAllConservationProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConservationProjectById(string id)
        {
            var project = await _conservationProjectService.GetConservationProjectByIdAsync(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConservationProject([FromBody] ConservationProject conservationProject)
        {
            conservationProject.ProjectId = Guid.NewGuid().ToString();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _conservationProjectService.CreateConservationProjectAsync(conservationProject);
            return CreatedAtAction(nameof(GetConservationProjectById), new { id = conservationProject.ProjectId }, conservationProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConservationProject(string id, [FromBody] ConservationProject conservationProject)
        {
            if (id != conservationProject.ProjectId)
                return BadRequest("Project ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProject = await _conservationProjectService.GetConservationProjectByIdAsync(id);
            if (existingProject == null)
                return NotFound();

            await _conservationProjectService.UpdateConservationProjectAsync(conservationProject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConservationProject(string id)
        {
            var existingProject = await _conservationProjectService.GetConservationProjectByIdAsync(id);
            if (existingProject == null)
                return NotFound();

            await _conservationProjectService.DeleteConservationProjectAsync(id);
            return NoContent();
        }

        [HttpGet("contributor/{contributorId}")]
        public async Task<ActionResult<IEnumerable<ConservationProject>>> GetProjectsByContributorId(string contributorId)
        {
            var projects = await _conservationProjectService.GetProjectsByContributorIdAsync(contributorId);
            if (projects == null || projects.Count == 0)
            {
                return NotFound(new { message = "No projects found for this contributor." });
            }
            return Ok(projects);
        }
    }
}
