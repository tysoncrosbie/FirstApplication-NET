namespace Api.Dtos.Comment;

public record CommentDto(
    int Id,
    string Title,
    string Content,
    DateTime CreatedOn,
    int? StockId
);