namespace SportsForum.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using SportsForum.Data.Common.Repositories;
    using SportsForum.Data.Models;
    using SportsForum.Services.Mapping;
    using SportsForum.Web.ViewModels.Home;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<T> GetCategories<T>(int? count = null)
        {
            IQueryable<Category> query = this.categoryRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
           return this.categoryRepository.All().Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-")).To<T>().FirstOrDefault();
        }
    }
}
