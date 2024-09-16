using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Stock
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string? Symbol { get; set; }
    [MaxLength(100)]
    public string? CompanyName { get; set; } 
    [Column(TypeName = "decimal(18,2)")] 
    public decimal Purchase { get; set; }
    [Column(TypeName = "decimal(18,2)")] 
    public decimal LastDiv { get; set; }
    [MaxLength(200)]
    public string? Industry { get; set; } 
    public long? MarketCap { get; set; }

    public List<Comment> Comments { get; init; } = new();
    public List<Portfolio> Portfolios { get; } = new();
}