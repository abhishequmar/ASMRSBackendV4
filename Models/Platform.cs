using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class Platform
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();
        [Key]
        public string PlatformId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        //[ForeignKey("Site")]
        public string UserId { get; set; } = Guid.NewGuid().ToString();  // Foreign key for User

        [Required]
        [StringLength(50)]
        public string DeviceType { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastAccessDate { get; set; }

        [Required]
        [StringLength(20)]
        public string PreferredLanguage { get; set; }

        // Navigation property for one-to-one relationship with User
        //public virtual User User { get; set; }
    }
}
