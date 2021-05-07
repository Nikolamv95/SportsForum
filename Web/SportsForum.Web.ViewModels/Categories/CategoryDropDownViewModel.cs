namespace SportsForum.Web.ViewModels.Categories
{
    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
