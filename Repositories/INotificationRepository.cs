//using AsmrsBackend.Models;

//namespace AsmrsBackend.Repositories
//{
//    public interface INotificationRepository
//    {
//        Task<Notification> GetNotificationByIdAsync(int notificationId);
//        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
//        Task CreateNotificationAsync(Notification notification);
//        Task UpdateNotificationAsync(Notification notification);
//        Task DeleteNotificationAsync(int notificationId);
//    }
//}

using AsmrsBackend.Models;

namespace AsmrsBackend.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> GetNotificationByIdAsync(string notificationId);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task CreateNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(string notificationId);
    }
}
