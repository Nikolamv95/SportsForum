namespace SportsForum.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using SportsForum.Data.Common.Repositories;
    using SportsForum.Data.Models;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> votesRepository;

        public VoteService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.votesRepository.All().FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                var newVote = new Vote()
                {
                    UserId = userId,
                    PostId = postId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(newVote);
            }

            await this.votesRepository.SaveChangesAsync();
        }

        public int GetAllVotes(int postId)
        {
            return this.votesRepository
                .All()
                .Where(x => x.PostId == postId)
                .Sum(x => (int)x.Type);
        }
    }
}
