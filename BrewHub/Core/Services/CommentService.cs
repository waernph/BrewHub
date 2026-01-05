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

        public async Task DeleteComment(int CommentId)
        {
            await _repo.DeleteComment(CommentId);
        }


        public async Task NewComment(string commentBody, int userId, int postId)
        {
            await _repo.AddComment(postId, userId, commentBody);
        }

        public async Task UpdateComment(int CommentId, string NewCommentText)
        {
            await _repo.UpdateComment(CommentId, NewCommentText);
        }

        public async Task DeleteCommentsByPostId(int PostId)
        {
            await _repo.DeleteCommentsByPostId(PostId);
        }
    }
}
