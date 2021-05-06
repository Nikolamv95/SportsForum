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

            var categories = new List<string>() {"Sport", "News", "Music", "Programming", "Dogs", "Cat"};
            foreach (var category in categories)
            {
                await dbContext.AddAsync(new Category()
                {
                    Name = category,
                    Description = category,
                    Tittle = category,
                });
            }
        }
    }
}
