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

        public void AddComment(int PostId, int UserId, string inputCommentText)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserId == UserId);
            var comment = new Comment { CommentText = inputCommentText, User = user };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(int inputCommentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentID == inputCommentId);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(int CommentId, string NewCommentText)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentID == CommentId);
            comment.CommentText = NewCommentText;
            _context.SaveChanges();
        }

        public List<Comment> GetComments(int PostId)
        {
            var comments = _context.Comments.ToList();
            var commentsById = comments.Where(c => c.CommentID == PostId).ToList();


            return commentsById;
        }
    }
}
