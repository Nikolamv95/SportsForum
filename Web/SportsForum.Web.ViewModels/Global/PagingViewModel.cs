namespace SportsForum.Web.ViewModels.Global
{
    using System;

    public class PagingViewModel
    {
        public int CurrentPage { get; set; }

        public int PostsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PagesCount { get; set; }
    }
}
