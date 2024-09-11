namespace Api.Models;

public class Comment
{
    public int Id { get; init; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedOn { get; init; } = DateTime.Now;

    public int? StockId { get; init; }
    public Stock? Stock { get; init; }
}