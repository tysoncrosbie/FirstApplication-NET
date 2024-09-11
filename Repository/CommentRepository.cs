using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class CommentRepository(AppDbContext context) : ICommentRepository
{
    public async Task<Comment> CreateAsync(Comment comment)
    {
        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
    {
        var comment = await context.Comments.FindAsync(id);

        if (comment == null) return null;

        comment.Title = commentModel.Title;
        comment.Content = commentModel.Content;

        await context.SaveChangesAsync();

        return comment;
    }


    public async Task<Comment?> DeleteAsync(int id)
    {
        var comment = context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment == null) return null;

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();

        return comment;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetIdAsync(int id)
    {
        return await context.Comments.FindAsync(id);
    }
}