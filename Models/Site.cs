using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class Site
    {
        [BsonId]
        public ObjectId DId { get; set; }
        [Key]

        [Required]
        public string? SiteId { get; set; } = Guid.NewGuid().ToString(); 

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(50)]
        public string HistoricalPeriod { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public string DiscoveredById { get; set; }

        [StringLength(50)]
        public string ConservationStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateDiscovered { get; set; }

        // Add the ImageUrl property
        [StringLength(500)]
        public string ImageUrl { get; set; }

        // Navigation Properties for One-to-Many Relationships
        //public virtual ICollection<Artifact> Artifacts { get; set; }
        //public virtual ICollection<ConservationProject> ConservationProjects { get; set; }
        //public virtual ICollection<VisitorTour> VisitorTours { get; set; }
        //public virtual ICollection<Publication> Publications { get; set; }
        //public virtual ICollection<Report> Reports { get; set; }
        //public virtual ICollection<Excavation> Excavations { get; set; }
        //public virtual ICollection<User> Users { get; set; }

        // Navigation Property for One-to-One Relationship with Map
        //public virtual Map Map { get; set; }
        //public virtual User DiscoveredByUser { get; set; }
    }


}
