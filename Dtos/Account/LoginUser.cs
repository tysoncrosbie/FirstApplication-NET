using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Account;

public record LoginUser(
    [Required(ErrorMessage = "Username is required")]
    string Username,
    [Required(ErrorMessage = "Password is required")]
    string Password
);