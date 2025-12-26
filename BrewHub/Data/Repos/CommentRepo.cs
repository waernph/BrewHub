using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrewHub.Data.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly BrewHubContext _context;
        public CommentRepo(BrewHubContext context)
        {
            _context = context;
        }

        public async Task AddComment(int PostId, int UserId, string inputCommentText)
        {
            User user = _context.Users.First(u => u.UserId == UserId);
            var comment = new Comment { CommentText = inputCommentText, User = user, PostId = PostId };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public async Task DeleteComment(int inputCommentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == inputCommentId);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public async Task UpdateComment(int CommentId, string NewCommentText)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == CommentId);
            comment.CommentText = NewCommentText;
            _context.SaveChanges();
        }

        public async Task<List<Comment>> GetComments(int PostId)
        {
            var comments = _context.Comments.ToList();
            var commentsById = comments.Where(c => c.CommentId == PostId).ToList();


            return commentsById;
        }
    }
}
