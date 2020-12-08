namespace PictureGallery.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using PictureGallery.Data.Common.Repositories;
    using PictureGallery.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuepairs()
        {
            return this.categoriesRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

        }
    }
}
