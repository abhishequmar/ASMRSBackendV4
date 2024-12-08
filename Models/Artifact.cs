namespace AsmrsBackend.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;

    public class Artifact
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();
        [Key]
        public string ArtifactId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string SiteId { get; set; }
        [Required]
        public string DiscoveredById { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Material { get; set; }

        [Required]
        [StringLength(50)]
        public string Condition { get; set; }

        [StringLength(500)]
        public string CulturalSignificance { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFound { get; set; }

        [Required]
        [StringLength(50)]
        public string PreservationStatus { get; set; }
        public string CurrentLocation { get; set; }
        public string PreviousLocation { get; set; }


        // Navigation Property for Many-to-One Relationship with Site
        //[ForeignKey("SiteId")]
        //public virtual Site Site { get; set; }

        // Navigation Property for One-to-One Relationship with ArtifactTracking
        //public virtual ArtifactTracking ArtifactTracking { get; set; }


    }



}
