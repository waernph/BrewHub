using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface ICommentRepo
    {
        Task AddComment(int PostId, int UserId, string CommentText);
        Task UpdateComment(int CommentId, string NewCommentText);
        Task<Comment> GetCommentById(int CommentId);
        Task DeleteComment(int CommentId);
        Task<List<Comment>> GetComments(int PostId);
        Task DeleteCommentsByPostId(int PostId);
    }
}
