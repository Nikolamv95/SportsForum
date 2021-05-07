namespace SportsForum.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        public IEnumerable<T> GetCategories<T>(int? count = null);

        T GetByName<T>(string name);
    }
}
