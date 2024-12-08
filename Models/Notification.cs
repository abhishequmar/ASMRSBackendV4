using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class Notification
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();
        [Key]
        public string NotificationId { get; set; } =Guid.NewGuid().ToString();

        [Required]
        //[ForeignKey("User")]
        public string UserId { get; set; } = Guid.NewGuid().ToString();  // Foreign key for User

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateSent { get; set; }

        [Required]
        [StringLength(50)]
        public string NotificationType { get; set; }

        [Required]
        public bool ReadStatus { get; set; }

        // Navigation property for many-to-one relationship with User
        //public virtual User User { get; set; }
    }
}
