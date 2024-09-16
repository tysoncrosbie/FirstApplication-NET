using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Comment
{
    public int Id { get; init; }
    [MinLength(5, ErrorMessage = "Title must be 5 characters"), MaxLength(100, ErrorMessage = "Title cannot be over 100 characters")]
    public required string? Title { get; set; }
    [MinLength(5, ErrorMessage = "Content must be 5 characters"), MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")]
    public required string? Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int? StockId { get; set; }
    public Stock? Stock { get; set; }
    
    [MaxLength(100)]
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}