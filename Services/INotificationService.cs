using AsmrsBackend.Models;

namespace AsmrsBackend.Services
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationByIdAsync(string notificationId);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task CreateNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(string notificationId);
    }
}
