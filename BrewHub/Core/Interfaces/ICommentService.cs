using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface ICommentService
    {
        Task NewComment(string commentBody, int userId, int postId);
        Task UpdateComment(int CommentId, string NewCommentText, int userId);
        Task DeleteComment(int CommentId, int userId);
        Task DeleteCommentsByPostId(int PostId);

    }
}
