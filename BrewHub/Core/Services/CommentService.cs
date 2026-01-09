using BrewHub.Core.Interfaces;
using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;
using System.Net;

namespace BrewHub.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _repo;
        private readonly IPostRepo _postRepo;

        public CommentService(ICommentRepo repo, IPostRepo postRepo)
        {
            _repo = repo;
            _postRepo = postRepo;
        }

        public async Task DeleteComment(int CommentId, int userId)
        {
            var comment = await _repo.GetCommentById(CommentId);
            if (comment.UserId == userId)
                await _repo.DeleteComment(CommentId);
            else if (comment is null)
                throw new ArgumentException("The comment you are trying to delete does not exist.");
            else
                throw new UnauthorizedAccessException("You can only delete your own comments.");
        }


        public async Task NewComment(string commentBody, int userId, int postId)
        {
            if (await _postRepo.PostExists(postId) is null)
                throw new ArgumentException("The post you are trying to comment on does not exist.");

            await _repo.AddComment(postId, userId, commentBody);
            
        }

        public async Task UpdateComment(int CommentId, string NewCommentText, int userId)
        {
            var comment = await _repo.GetCommentById(CommentId);
            if (comment == null)
                throw new ArgumentException("The comment you are trying to update does not exist.");
            else if (comment.UserId == userId)
                await _repo.UpdateComment(CommentId, NewCommentText);
            else
                throw new UnauthorizedAccessException("You can only update your own comments.");
        }

        public async Task DeleteCommentsByPostId(int PostId)
        {
            await _repo.DeleteCommentsByPostId(PostId);
        }
    }
}
