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

    public static Comment ToCommentFromUpdate(this UpdateComment commentRequest)
    {
        return new Comment
        {
            Title = commentRequest.Title,
            Content = commentRequest.Content
        };
    }

    public static Comment ToCommentFromDto(this CreateComment commentRequest, int stockId)
    {
        return new Comment
        {
            Title = commentRequest.Title,
            Content = commentRequest.Content,
            StockId = stockId
        };
    }
}