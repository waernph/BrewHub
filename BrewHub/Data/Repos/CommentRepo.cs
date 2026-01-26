using BrewHub.Data.Entities;
using BrewHub.Data.Interfaces;

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
            Post post = _context.Posts.First(p => p.PostId == PostId);
            if (post.UserId == UserId)
            {
                throw new Exception("Users cannot comment on their own posts.");
            }
            else
            {
                var comment = new Comment { CommentText = inputCommentText, User = user, PostId = PostId };
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteComment(int inputCommentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == inputCommentId);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComment(int CommentId, string NewCommentText)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == CommentId);
            comment.CommentText = NewCommentText;
            await _context.SaveChangesAsync();
        }
        public async Task<Comment> GetCommentById(int CommentId)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == CommentId);
            return comment;
        }

        public async Task<List<Comment>> GetComments(int PostId)
        {
            var comments = _context.Comments;
            var commentsById = comments.Where(c => c.CommentId == PostId).ToListAsync();


            return await commentsById;
        }

        public async Task DeleteCommentsByPostId(int PostId)
        {
            var comments = _context.Comments;
            var commentsById = await comments.Where(c => c.PostId == PostId).ToListAsync();
            _context.Comments.RemoveRange(commentsById);
            await _context.SaveChangesAsync();
        }
    }
}
