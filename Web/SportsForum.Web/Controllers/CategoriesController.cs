namespace SportsForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportsForum.Services.Data;
    using SportsForum.Web.ViewModels.Categories;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.categoryService.GetByName<CategoryViewModel>(name);
            return this.View(viewModel);
        }
    }
}
