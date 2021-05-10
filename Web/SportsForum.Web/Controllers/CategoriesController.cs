namespace SportsForum.Web.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using SportsForum.Services.Data;
    using SportsForum.Web.ViewModels.Categories;
    using SportsForum.Web.ViewModels.Posts;

    public class CategoriesController : BaseController
    {
        private const int ItemsPerPage = 5;

        private readonly ICategoriesService categoryService;
        private readonly IPostsService postsService;

        public CategoriesController(ICategoriesService categoryService, IPostsService postsService)
        {
            this.categoryService = categoryService;
            this.postsService = postsService;
        }

        public IActionResult ByName(string name, int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.categoryService.GetByName<CategoryViewModel>(name);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.ForumPosts =
                this.postsService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);

            viewModel.CurrentPage = page;
            viewModel.ItemsPerPage = ItemsPerPage;
            viewModel.PostsCount = this.postsService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)viewModel.PostsCount / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            return this.View(viewModel);
        }
    }
}
