namespace SportsForum.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using SportsForum.Data.Common.Repositories;
    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;
    using SportsForum.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        /// <summary>
        /// Returns the id of the newly created post.
        /// </summary>
        /// <param name="postInput"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> CreatePostAsync(PostCreateInputModel postInput, string userId)
        {
            var post = new Post()
            {
                CategoryId = postInput.CategoryId,
                Description = postInput.Content,
                Title = postInput.Title,
                UserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();

            return post.Id;
        }

        public T GetById<T>(int id)
        {
            var post = this.postRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
            return post;
        }
    }
}
