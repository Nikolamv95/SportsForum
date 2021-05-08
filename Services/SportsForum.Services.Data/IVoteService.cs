namespace SportsForum.Services.Data
{
    using System.Threading.Tasks;

    public interface IVoteService
    {
        /// <summary>
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <param name="isUpVote">If true - up vote, else - down vote.</param>
        /// <returns></returns>
        Task VoteAsync(int postId, string userId, bool isUpVote);

        public int GetAllVotes(int postId);
    }
}
