using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface ICommentService
    {
        Task NewComment(string commentBody, int userId, int postId);
        Task UpdateComment(int CommentId, string NewCommentText);
        Task DeleteComment(int CommentId);
        Task DeleteCommentsByPostId(int PostId);

    }
}
