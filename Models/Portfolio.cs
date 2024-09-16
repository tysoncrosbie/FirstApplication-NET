namespace Api.Models;

public class Portfolio
{
    public string? AppUserId { get; init; }
    public int StockId { get; init; }
    public AppUser? AppUser { get; init; }
    public Stock? Stock { get; init; }
}