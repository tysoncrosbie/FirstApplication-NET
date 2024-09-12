using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Stock
{
    public int Id { get; init; }
    public required string Symbol { get; set; }
    public required string CompanyName { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal LastDiv { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal Purchase { get; set; }

    public required string Industry { get; set; }
    public long MarketCap { get; set; }

    public List<Comment> Comments { get; init; } = [];
    public List<Portfolio> Portfolios { get; init; } = [];
}