namespace SportsForum.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SportsForum.Web.ViewModels.Posts;

    public interface IPostsService
    {
        public Task<int> CreatePostAsync(PostCreateInputModel postInput, string userId);

        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int take, int skip = 0);

        int GetCountByCategoryId(int categoryId);
    }
}
