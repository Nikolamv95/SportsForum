﻿namespace SportsForum.Web.ViewModels.Home
{
    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string PostsCount { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
