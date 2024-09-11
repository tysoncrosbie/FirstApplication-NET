using Api.Dtos.Comment;
using Api.Models;

namespace Api.Mappers;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        var commentDto = new CommentDto(
            commentModel.Id,
            commentModel.Title,
            commentModel.Content,
            commentModel.CreatedOn,
            commentModel.StockId);

        return commentDto;
    }

    public static Comment ToCommentFromUpdate(this UpdateCommentRequest updateRequest)
    {
        return new Comment
        {
            Title = updateRequest.Title,
            Content = updateRequest.Content
        };
    }

    public static Comment ToCommentFromDto(this CreateCommentRequest createRequest, int stockId)
    {
        return new Comment
        {
            Title = createRequest.Title,
            Content = createRequest.Content,
            StockId = stockId
        };
    }
}