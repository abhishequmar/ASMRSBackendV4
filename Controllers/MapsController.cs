using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapsController : ControllerBase
    {
        private readonly IMapService _mapService;

        public MapsController(IMapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaps()
        {
            var maps = await _mapService.GetAllMapsAsync();
            return Ok(maps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMapById(string id)
        {
            var map = await _mapService.GetMapByIdAsync(id);
            if (map == null)
                return NotFound();

            return Ok(map);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMap([FromBody] Map map)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mapService.CreateMapAsync(map);
            return CreatedAtAction(nameof(GetMapById), new { id = map.MapId }, map);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMap(string id, [FromBody] Map map)
        {
            if (id != map.MapId)
                return BadRequest("Map ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingMap = await _mapService.GetMapByIdAsync(id);
            if (existingMap == null)
                return NotFound();

            await _mapService.UpdateMapAsync(map);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMap(string id)
        {
            var existingMap = await _mapService.GetMapByIdAsync(id);
            if (existingMap == null)
                return NotFound();

            await _mapService.DeleteMapAsync(id);
            return NoContent();
        }
    }
}
