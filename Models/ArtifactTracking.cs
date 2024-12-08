using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class ArtifactTracking
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();
        [Key]
        public string TrackingId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        //[ForeignKey("Artifact")]
        public string ArtifactId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(100)]
        public string CurrentLocation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateMoved { get; set; }

        [StringLength(100)]
        public string PreviousLocation { get; set; }

        [StringLength(200)]
        public string Purpose { get; set; }

        // Navigation Property for One-to-One Relationship with Artifact
        public virtual Artifact Artifact { get; set; }
    }

}
