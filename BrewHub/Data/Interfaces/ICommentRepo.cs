using BrewHub.Data.Entities;

namespace BrewHub.Data.Interfaces
{
    public interface ICommentRepo
    {
        public void AddComment(int PostId, int UserId, string CommentText);
        public void UpdateComment(int CommentId, string NewCommentText);
        public void DeleteComment(int CommentId);
        public List<Comment> GetComments(int PostId);
    }
}
