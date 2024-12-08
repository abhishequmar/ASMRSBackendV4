using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using AsmrsBackend.Data;

namespace AsmrsBackend.Models
{
    public class VisitorTour
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("TourId"), BsonRepresentation(BsonType.String)]
        public string TourId { get; set; } = Guid.NewGuid().ToString(); 

        [Required(ErrorMessage = "Site ID is required.")]
        [BsonElement("SiteId"), BsonRepresentation(BsonType.String)]
        public string SiteId { get; set; } = Guid.NewGuid().ToString();  // Many-to-one relation with Site based on SiteId

        [Required(ErrorMessage = "Tour Guide ID is required.")]
        [BsonElement("TourGuideId"), BsonRepresentation(BsonType.String)]
        public string TourGuideId { get; set; } = Guid.NewGuid().ToString(); // Many-to-one relation with User (TourGuide) based on UserId

        [Required(ErrorMessage = "Tour date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Tour time is required.")]
        [BsonElement("Time"), BsonRepresentation(BsonType.String)]
        public string Time { get; set; }

        [Required(ErrorMessage = "Tour capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Tour duration is required.")]
        [StringLength(100, ErrorMessage = "Duration must be at most 100 characters long.")]
        [BsonElement("Duration"), BsonRepresentation(BsonType.String)]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Tour description is required.")]
        [StringLength(100, ErrorMessage = "Description must be at most 100 characters long.")]
        [BsonElement("Description"), BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Booking status is required.")]
        [StringLength(5, ErrorMessage = "Booking status must be at most 50 characters long.")]
        [BsonElement("BookingStatus"), BsonRepresentation(BsonType.String)]
        public string BookingStatus { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [StringLength(200, ErrorMessage = "Image URL must be at most 200 characters long.")]
        [BsonElement("ImageUrl"), BsonRepresentation(BsonType.String)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Site name is required.")]
        public string SiteName { get; set; }

        // List of nullable visitor IDs
        [BsonElement("VisitorIds"), BsonRepresentation(BsonType.String)]
        public List<string?> VisitorIds { get; set; } = new List<string?>();
    }
}
