using AsmrsBackend.Models;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsmrsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(string id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] Notification notification)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _notificationService.CreateNotificationAsync(notification);
            return CreatedAtAction(nameof(GetNotificationById), new { id = notification.NotificationId }, notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(string id, [FromBody] Notification notification)
        {
            if (id != notification.NotificationId)
                return BadRequest("Notification ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingNotification = await _notificationService.GetNotificationByIdAsync(id);
            if (existingNotification == null)
                return NotFound();

            await _notificationService.UpdateNotificationAsync(notification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(string id)
        {
            var existingNotification = await _notificationService.GetNotificationByIdAsync(id);
            if (existingNotification == null)
                return NotFound();

            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}
