namespace SportsForum.Web.ViewModels.Posts
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Description, @"<[^>]+>", string.Empty));
                return content.Length > 300
                    ? content.Substring(0, 300) + "..."
                    : content;
            }
        }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
