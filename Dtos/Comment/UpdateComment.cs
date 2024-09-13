using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Comment;

public record UpdateComment(
    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 characters")]
    [MaxLength(100, ErrorMessage = "Title cannot be over 100 characters")]
    string Title,
    [Required]
    [MinLength(5, ErrorMessage = "Content must be 5 characters")]
    [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")]
    string Content
);