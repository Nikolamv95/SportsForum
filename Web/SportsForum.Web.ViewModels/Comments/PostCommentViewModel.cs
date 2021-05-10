namespace SportsForum.Web.ViewModels.Comments
{
    using System;

    using Ganss.XSS;
    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
