using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Account;

public record RegisterUser(
    [Required] string? Username,
    [Required] [EmailAddress] string? Email,
    [Required] string? Password
);