namespace SportsForum.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using SportsForum.Services.Data;
    using SportsForum.Web.ViewModels;
    using SportsForum.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoryService;

        public HomeController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Categories = this.categoryService.GetCategories<IndexCategoryViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
