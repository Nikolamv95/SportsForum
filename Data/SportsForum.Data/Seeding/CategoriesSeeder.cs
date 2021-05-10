namespace SportsForum.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SportsForum.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<string>() { "Football", "Baseball", "Tennis", "Basketball", "American Football", "Golf" };
            foreach (var category in categories)
            {
                await dbContext.AddAsync(new Category()
                {
                    Name = category,
                    Description = $"The object of this category is to discuss different {category} questions.",
                    Title = category,
                });
            }
        }
    }
}
