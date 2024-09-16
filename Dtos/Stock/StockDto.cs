using Api.Dtos.Comment;

namespace Api.Dtos.Stock;

public record StockDto(
    int Id,
    string? Symbol,
    string? CompanyName,
    decimal LastDiv,
    decimal Purchase,
    string? Industry,
    long? MarketCap,
    List<CommentDto> Comments
);