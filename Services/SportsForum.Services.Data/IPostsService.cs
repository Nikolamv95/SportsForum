namespace SportsForum.Services.Data
{
    using System.Threading.Tasks;

    using SportsForum.Web.ViewModels.Posts;

    public interface IPostsService
    {
        public Task<int> CreatePostAsync(PostCreateInputModel postInput, string userId);

        T GetById<T>(int id);
    }
}
