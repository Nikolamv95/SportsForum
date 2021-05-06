namespace SportsForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        public IActionResult ById()
        {
            return this.View();
        }
    }
}
