using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class Report
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();
        [Key]
        public string ReportId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        //[ForeignKey("Site")]
        public string SiteId { get; set; } = Guid.NewGuid().ToString();  // Foreign key for Site

        [Required]
        [StringLength(100)]
        public string ReportType { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateGenerated { get; set; }

        [Required]
        //[ForeignKey("User")]
        public string GeneratedBy { get; set; } = Guid.NewGuid().ToString();  // Foreign key for User (GeneratedBy)

        
    }
}
