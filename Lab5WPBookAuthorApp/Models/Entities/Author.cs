using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5WPBookAuthorApp.Models.Entities;

public class Author
{
    public int Id { get; set; }

    [StringLength(128)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(128)]
    public string LastName { get; set; } = string.Empty;

    public int BookId { get; set; }
        
    [JsonIgnore]
    public Book Book { get; set; } = null!;
}