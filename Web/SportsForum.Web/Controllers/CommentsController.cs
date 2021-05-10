namespace SportsForum.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SportsForum.Data.Models;
    using SportsForum.Services.Data;
    using SportsForum.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputModel input)
        {
            var parentId = input.ParentId == 0 ? (int?)null : input.ParentId;

            if (parentId.HasValue)
            {
                if (!this.commentService.IsInPostId(parentId.Value, input.PostId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.commentService.CreateAsync(input.PostId, userId, input.Content, parentId);

            return this.RedirectToAction("ById", "Posts", new { id = input.PostId });
        }
    }
}
