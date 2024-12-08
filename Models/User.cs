using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AsmrsBackend.Models
{
    public class User
    {
        [BsonId]
        public ObjectId DId { get; set; } = ObjectId.GenerateNewId();
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression("^(Admin|Archaeologist|Conservator|Researcher|Visitor|Tourguide)$", ErrorMessage = "Role must be either 'Admin', 'Archaeologist', 'Conservator', 'Researcher', 'Visitor', 'Tourguide' .")]
        public string Role { get; set; }

        public string? PhoneNumber { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? LastLogin { get; set; }


        // Navigation Property for Many-to-One Relationship with Site
        //public int SiteId { get; set; }

        // Navigation Property for One-to-Many Relationships with other models
        //public virtual ICollection<VisitorTour>? VisitorTours { get; set; }
        //public virtual ICollection<Publication>? Publications { get; set; }
        //public virtual ICollection<Report>? Reports { get; set; }
        //public virtual ICollection<Excavation>? Excavations { get; set; }
        //public virtual ICollection<Notification>? Notifications { get; set; }
        //public virtual ICollection<Site>? DiscoveredSites { get; set; }

        //// Navigation Property for One-to-One Relationship with Platform
        //public virtual Platform? Platform { get; set; }
    }
}
