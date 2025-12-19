using BrewHub.Core.Interfaces;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;

namespace BrewHub.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _repo;

        public CommentService(ICommentRepo repo)
        {
            _repo = repo;
        }

        public void DeleteComment(int CommentId)
        {
            _repo.DeleteComment(CommentId);
        }

        public List<Comment> GetComments(int PostId)
        {
            return _repo.GetComments(PostId);
        }

        public void NewComment(string commentBody, int userId, int postId)
        {
            _repo.AddComment(postId, userId, commentBody);
        }

        public void UpdateComment(int CommentId, string NewCommentText)
        {
            _repo.UpdateComment(CommentId, NewCommentText);
        }
    }
}
