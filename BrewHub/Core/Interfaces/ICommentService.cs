using BrewHub.Data.Entities;

namespace BrewHub.Core.Interfaces
{
    public interface ICommentService
    {
        public void NewComment(string commentBody, int userId, int postId);
        public void UpdateComment(int CommentId, string NewCommentText);
        public void DeleteComment(int CommentId);
        public List<Comment> GetComments(int PostId);

    }
}
