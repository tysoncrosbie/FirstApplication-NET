using Api.Helpers;
using Api.Models;

namespace Api.Interfaces;

public interface ICommentRepository
{
    Task<Comment?> GetIdAsync(int id);
    Task<Comment> CreateAsync(Comment comment);
    Task<Comment?> UpdateAsync(int id, Comment commentModel);
    Task<Comment?> DeleteAsync(int id);
    Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject);
}