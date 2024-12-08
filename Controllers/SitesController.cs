using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitesController : ControllerBase
    {
        private readonly ISiteService _siteService;

        public SitesController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        // GET api/sites
        [HttpGet]
        public async Task<IActionResult> GetAllSites()
        {   Console.WriteLine("get all called");
            var sites = await _siteService.GetAllSitesAsync();
            if (sites == null || !sites.Any()) // Use Any() for IEnumerable
            {
                return NotFound("No sites found.");
            }
            return Ok(sites);
        }

        // GET api/sites/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiteById(string id)
        {
            Console.WriteLine("1 called");
            var site = await _siteService.GetSiteByIdAsync(id);
            if (site == null)
            {
                return NotFound($"Site with ID {id} not found.");
            }
            return Ok(site);
        }

        // POST api/sites
        [HttpPost]
        public async Task<IActionResult> CreateSite([FromBody] Site site)
        {
            if (site == null)
            {
                return BadRequest("Site data is required.");
            }
            site.SiteId = Guid.NewGuid().ToString();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            await _siteService.CreateSiteAsync(site);
            
            // Returning CreatedAtAction which includes the location of the created resource
            return CreatedAtAction(nameof(GetSiteById), new { id = site.SiteId }, site);
        }

        // PUT api/sites/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSite(string id, [FromBody] Site site)
        {
            if (id != site.SiteId)
            {
                return BadRequest("Site ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSite = await _siteService.GetSiteByIdAsync(id);
            if (existingSite == null)
            {
                return NotFound($"Site with ID {id} not found.");
            }

            await _siteService.UpdateSiteAsync(site);
            return NoContent();
        }

        // DELETE api/sites/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite(string id)
        {
            var existingSite = await _siteService.GetSiteByIdAsync(id);
            if (existingSite == null)
            {
                return NotFound($"Site with ID {id} not found.");
            }

            await _siteService.DeleteSiteAsync(id);
            return NoContent();
        }

        // GET api/sites/GetByDiscoveredBy/{discoveredById}
        [HttpGet("GetByDiscoveredBy/{discoveredById}")]
        public async Task<ActionResult<Site[]>> GetSiteByDiscoveredById(string discoveredById)
        {
            if (string.IsNullOrEmpty(discoveredById))
            {
                return BadRequest("DiscoveredById is required.");
            }

            var sites = await _siteService.GetSiteByDiscoveredByIdAsync(discoveredById);
            if (sites == null || !sites.Any()) // Use Any() to check for empty
            {
                return NotFound($"No sites found discovered by {discoveredById}.");
            }
            return Ok(sites);
        }
    }
}
