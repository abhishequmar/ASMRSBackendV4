using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class Map
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();
        [Key]
        public string MapId { get; set; } = Guid.NewGuid().ToString();  

        [Required]
        //[ForeignKey("Site")]
        public string SiteId { get; set; } = Guid.NewGuid().ToString(); // Foreign key for Site

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string MapType { get; set; }

        [Required]
        public string Coordinates { get; set; }

        [StringLength(500)]
        public string DataLayers { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        // Navigation property for the one-to-one relationship with Site
        //public virtual Site Site { get; set; }
    }
}
