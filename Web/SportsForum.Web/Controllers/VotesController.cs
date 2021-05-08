namespace SportsForum.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SportsForum.Data.Models;
    using SportsForum.Services.Data;
    using SportsForum.Web.ViewModels.Votes;

    [ApiController]
    [Route("/api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVoteService voteService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVoteService voteService, UserManager<ApplicationUser> userManager)
        {
            this.voteService = voteService;
            this.userManager = userManager;
        }

        // POST /api/votes
        // Request body: {"postId": 1, "isVoteUp":true}
        // Response body: {"VotesCount": int number}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel voteInput)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.voteService.VoteAsync(voteInput.PostId, userId, voteInput.IsUpVote);
            var votes = this.voteService.GetAllVotes(voteInput.PostId);

            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
