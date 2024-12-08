using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class Excavation
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();

        public string ExcavationId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Site ID is required.")]
        public string SiteId { get; set; } = Guid.NewGuid().ToString();  // Foreign key for Site

        [Required(ErrorMessage = "Site name is required.")]
        [StringLength(100, ErrorMessage = "Site name must be at most 100 characters long.")]
        public string SiteName { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 150 characters long.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        [Required(ErrorMessage = "Lead archaeologist ID is required.")]
        public string LeadArchaeologistId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Lead archaeologist name is required.")]
        [StringLength(100, ErrorMessage = "Lead archaeologist name must be at most 100 characters long.")]
        public string LeadArchaeologistName { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status must be at most 50 characters long.")]
        public string Status { get; set; }

        public List<string> TeamMembers { get; set; } = new List<string>();

        
    }
}
