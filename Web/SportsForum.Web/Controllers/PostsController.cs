namespace SportsForum.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SportsForum.Data.Models;
    using SportsForum.Services.Data;
    using SportsForum.Web.ViewModels.Categories;
    using SportsForum.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, ICategoriesService categoriesService , UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var model = new PostCreateInputModel()
            {
                Categories = this.categoriesService.GetCategories<CategoryDropDownViewModel>(),
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel postInput)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(postInput);
            }

            var userId = this.userManager.GetUserId(this.User);
            var postId = await this.postsService.CreatePostAsync(postInput, userId);

            return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }

        [HttpGet]
        public IActionResult ById(int? id)
        {
            // TODO: Remove null value ?
            return this.View();
        }
    }
}
