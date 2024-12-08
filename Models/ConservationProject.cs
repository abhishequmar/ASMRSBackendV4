using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class ConservationProject
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();

        [Key]
        public string ProjectId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Site ID is required.")]
        public string SiteId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Site Name is required.")]
        [StringLength(200, ErrorMessage = "Site Name must not exceed 200 characters.")]
        public string SiteName { get; set; }

        [Required(ErrorMessage = "Objective is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Objective must be between 10 and 500 characters.")]
        public string Objective { get; set; }

        [Required(ErrorMessage = "Conservation Method is required.")]
        [StringLength(200, ErrorMessage = "Conservation Method must not exceed 200 characters.")]
        public string ConservationMethod { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Start Date must be a valid date.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "End Date must be a valid date.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Funding Source is required.")]
        [StringLength(100, ErrorMessage = "Funding Source must not exceed 100 characters.")]
        public string FundingSource { get; set; }

        [Required(ErrorMessage = "At least one Contributor ID is required.")]
        public List<string> ContributorIds { get; set; } = new List<string>();
    }
}
