namespace SportsForum.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;
    using SportsForum.Web.ViewModels.Posts;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<PostInCategoryViewModel> Posts { get; set; }
    }
}
