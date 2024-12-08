using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorToursController : ControllerBase
    {
        private readonly IVisitorTourService _visitorTourService;

        public VisitorToursController(IVisitorTourService visitorTourService)
        {
            _visitorTourService = visitorTourService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisitorTours()
        {
            var tours = await _visitorTourService.GetAllVisitorToursAsync();
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitorTourById(string id)
        {
            var tour = await _visitorTourService.GetVisitorTourByIdAsync(id);
            if (tour == null)
                return NotFound();

            return Ok(tour);
        }

        [HttpPost]
        [Authorize(Policy = "TourguideOnly")]
        public async Task<IActionResult> CreateVisitorTour([FromBody] VisitorTour visitorTour)
        {

            visitorTour.TourId=Guid.NewGuid().ToString() ;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _visitorTourService.CreateVisitorTourAsync(visitorTour);
            return CreatedAtAction(nameof(GetVisitorTourById), new { id = visitorTour.TourId }, visitorTour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisitorTour(string id, [FromBody] VisitorTour visitorTour)
        {
           if (id != visitorTour.TourId)
               return BadRequest("Tour ID mismatch");

           if (!ModelState.IsValid)
               return BadRequest(ModelState);

           var existingTour = await _visitorTourService.GetVisitorTourByIdAsync(id);
           if (existingTour == null)
               return NotFound();

           await _visitorTourService.UpdateVisitorTourAsync(visitorTour);
           return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "TourguideOnly")]
        public async Task<IActionResult> DeleteVisitorTour(string id)
        {
            var existingTour = await _visitorTourService.GetVisitorTourByIdAsync(id);
            if (existingTour == null)
                return NotFound();

            await _visitorTourService.DeleteVisitorTourAsync(id);
            return NoContent();
        }

        [HttpPost("join")]
        public async Task<IActionResult> JoinTour([FromBody] JoinTourRequest request)
        {
            Console.WriteLine("join tour hit/////////////////////////////");
            var result = await _visitorTourService.JoinTourAsync(request.visitorTour, request.userEmail);

            return result switch
            {
                "Successfully joined the tour." => Ok(new { message = result }),
                "Tour not found." => NotFound(new { message = result }),
                "Tour is fully booked." or "You have already joined this tour." => BadRequest(new { message = result }),
                _ => StatusCode(500, new { message = "An error occurred." })
            };
        }

        [HttpGet("visitor/{visitorId}")]
        public async Task<IActionResult> GetVisitorToursByVisitorId(string visitorId)
        {
            var tours = await _visitorTourService.GetVisitorToursByVisitorIdAsync(visitorId);
            return Ok(tours);
        }

        // Get VisitorTours by TourGuideId
        [HttpGet("tourguide/{tourGuideId}")]
        [Authorize(Policy = "TourguideOnly")]

        public async Task<IActionResult> GetVisitorToursByTourGuideId(string tourGuideId)
        {
            var tours = await _visitorTourService.GetVisitorToursByTourGuideIdAsync(tourGuideId);
            if (tours == null || !tours.Any())
            {
                return NotFound();
            }
            return Ok(tours);
        }

    }
    public class JoinTourRequest
    {
        public VisitorTour visitorTour{get; set;}

        public string userEmail {get; set;}
    }

}
