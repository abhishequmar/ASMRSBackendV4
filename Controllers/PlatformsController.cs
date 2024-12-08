using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformsController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlatforms()
        {
            var platforms = await _platformService.GetAllPlatformsAsync();
            return Ok(platforms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformById(string id)
        {
            var platform = await _platformService.GetPlatformByIdAsync(id);
            if (platform == null)
                return NotFound();

            return Ok(platform);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform([FromBody] Platform platform)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _platformService.CreatePlatformAsync(platform);
            return CreatedAtAction(nameof(GetPlatformById), new { id = platform.PlatformId }, platform);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatform(string id, [FromBody] Platform platform)
        {
            if (id != platform.PlatformId)
                return BadRequest("Platform ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingPlatform = await _platformService.GetPlatformByIdAsync(id);
            if (existingPlatform == null)
                return NotFound();

            await _platformService.UpdatePlatformAsync(platform);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(string id)
        {
            var existingPlatform = await _platformService.GetPlatformByIdAsync(id);
            if (existingPlatform == null)
                return NotFound();

            await _platformService.DeletePlatformAsync(id);
            return NoContent();
        }
    }
}
