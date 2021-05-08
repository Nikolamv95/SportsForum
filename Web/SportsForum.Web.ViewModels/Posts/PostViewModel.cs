using System.Linq;
using AutoMapper;

namespace SportsForum.Web.ViewModels.Posts
{
    using System;

    using Ganss.XSS;
    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Description);

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            // When you map from post to PostViewModel for property VotesCount do the following logic:

            configuration.CreateMap<Post, PostViewModel>().ForMember(x => x.VotesCount, opt =>
            {
                opt.MapFrom(v => v.Votes.Sum(p => (int) p.Type));
            });
        }
    }
}
