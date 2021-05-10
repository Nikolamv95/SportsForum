namespace SportsForum.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task CreateAsync(int postId, string userId, string content, int? parentId = null);

        bool IsInPostId(int commentId, int postId);
    }
}
