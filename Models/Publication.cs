using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Publication
{
    [BsonId]
    public ObjectId DId { get; set; } = ObjectId.GenerateNewId();

    [Key]
    public string PublicationId { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Site ID is required.")]
    public string SiteId { get; set; } = Guid.NewGuid().ToString(); // Foreign key for Site

    [Required(ErrorMessage = "Author ID is required.")]
    public string AuthorId { get; set; } = Guid.NewGuid().ToString(); // Foreign key for User (Author)

    [Required(ErrorMessage = "Author name is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Author name must be between 3 and 100 characters.")]
    public string AuthorName { get; set; } // Author's ID, can be mapped to User

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 200 characters.")]
    public string Title { get; set; }

    [StringLength(1000, ErrorMessage = "Abstract cannot exceed 1000 characters.")]
    public string Abstract { get; set; }

    [Required(ErrorMessage = "Date Published is required.")]
    public string DatePublished { get; set; } 

    [Required(ErrorMessage = "File link is required.")]
    [Url(ErrorMessage = "Invalid URL format for File Link.")]
    public string FileLink { get; set; }
}
