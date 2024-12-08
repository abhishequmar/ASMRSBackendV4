//using AsmrsBackend.Data;
//using AsmrsBackend.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AsmrsBackend.Repositories
//{
//    public class NotificationRepository : INotificationRepository
//    {
//        private readonly AppDbContext _context;

//        public NotificationRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Notification> GetNotificationByIdAsync(int notificationId)
//        {
//            return await _context.Notifications.FindAsync(notificationId);
//        }

//        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
//        {
//            return await _context.Notifications.ToListAsync();
//        }

//        public async Task CreateNotificationAsync(Notification notification)
//        {
//            await _context.Notifications.AddAsync(notification);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateNotificationAsync(Notification notification)
//        {
//            _context.Notifications.Update(notification);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteNotificationAsync(int notificationId)
//        {
//            var notification = await _context.Notifications.FindAsync(notificationId);
//            if (notification != null)
//            {
//                _context.Notifications.Remove(notification);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}


using AsmrsBackend.Models;
using MongoDB.Driver;

namespace AsmrsBackend.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IMongoCollection<Notification> _notifications;

        public NotificationRepository(IMongoDatabase database)
        {
            _notifications = database.GetCollection<Notification>("Notifications");
        }

        public async Task<Notification> GetNotificationByIdAsync(string notificationId)
        {
            return await _notifications.Find(n => n.NotificationId == notificationId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _notifications.Find(_ => true).ToListAsync();
        }

        public async Task CreateNotificationAsync(Notification notification)
        {
            await _notifications.InsertOneAsync(notification);
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _notifications.ReplaceOneAsync(n => n.NotificationId == notification.NotificationId, notification);
        }

        public async Task DeleteNotificationAsync(string notificationId)
        {
            await _notifications.DeleteOneAsync(n => n.NotificationId == notificationId);
        }
    }
}
