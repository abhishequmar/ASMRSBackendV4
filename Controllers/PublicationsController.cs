using Microsoft.AspNetCore.Mvc;
using AsmrsBackend.Models;
using AsmrsBackend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsmrsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationService _publicationService;

        public PublicationsController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> GetPublicationById(string id)
        {
            var publication = await _publicationService.GetPublicationByIdAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            return Ok(publication);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> GetAllPublications()
        {
            var publications = await _publicationService.GetAllPublicationsAsync();
            return Ok(publications);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePublication([FromBody] Publication publication)
        {
            publication.PublicationId = Guid.NewGuid().ToString();
            publication.DatePublished =  DateOnly.FromDateTime(DateTime.Today).ToString();
            if (publication == null)
            {
                return BadRequest();
            }

            await _publicationService.CreatePublicationAsync(publication);
            return CreatedAtAction(nameof(GetPublicationById), new { id = publication.PublicationId }, publication);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePublication(string id, [FromBody] Publication publication)
        {
            if (id != publication.PublicationId)
            {
                return BadRequest();
            }

            await _publicationService.UpdatePublicationAsync(publication);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePublication(string id)
        {
            await _publicationService.DeletePublicationAsync(id);
            return NoContent();
        }

        [HttpGet("site/{siteId}")]
        public async Task<ActionResult<IEnumerable<Publication>>> GetPublicationsBySiteIdAsync(string siteId)
        {
            var publications = await _publicationService.GetPublicationsBySiteIdAsync(siteId);
            if (publications == null || !publications.Any())
            {
                return NotFound();
            }
            return Ok(publications);
        }

        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetPublicationsByAuthorId(string authorId)
        {
            var publications = await _publicationService.GetPublicationsByAuthorIdAsync(authorId);

            if (publications == null || !publications.Any())
            {
                return NotFound(new { Message = "No publications found for the specified author." });
            }

            return Ok(publications);
        }
    }
}
