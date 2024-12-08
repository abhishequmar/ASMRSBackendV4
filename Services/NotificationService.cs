using AsmrsBackend.Models;
using AsmrsBackend.Repositories;

namespace AsmrsBackend.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Notification> GetNotificationByIdAsync(string notificationId)
        {
            return await _notificationRepository.GetNotificationByIdAsync(notificationId);
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _notificationRepository.GetAllNotificationsAsync();
        }

        public async Task CreateNotificationAsync(Notification notification)
        {
            await _notificationRepository.CreateNotificationAsync(notification);
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _notificationRepository.UpdateNotificationAsync(notification);
        }

        public async Task DeleteNotificationAsync(string notificationId)
        {
            await _notificationRepository.DeleteNotificationAsync(notificationId);
        }
    }
}
