namespace SportsForum.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SportsForum.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
