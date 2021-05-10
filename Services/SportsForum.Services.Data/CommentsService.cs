using System.Linq;

namespace SportsForum.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using SportsForum.Data.Common.Repositories;
    using SportsForum.Data.Models;

    public class CommentsService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentsRepository = commentRepository;
        }

        public async Task CreateAsync(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                PostId = postId,
                UserId = userId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if the comment which the user wants to create is in the same post.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(x => x.PostId).FirstOrDefault();

            return commentPostId == postId;
        }
    }
}
