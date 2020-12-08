namespace PictureGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using PictureGallery.Data.Common.Repositories;
    using PictureGallery.Data.Models;
    using PictureGallery.Services.Mapping;
    using PictureGallery.Web.ViewModels.Pictures;

    public class PicturesService : IPicturesService
    {
        private readonly IDeletableEntityRepository<Picture> picturesRepository;

        public PicturesService(IDeletableEntityRepository<Picture> picturesRepository)
        {
            this.picturesRepository = picturesRepository;
        }

        public async Task CreateAsync(CreatePictureInputModel input, string userId, string imagePath)
        {
            var picture = new Picture();
            //picture.Category = input.CategoryId;
            picture.CreatedOn = DateTime.UtcNow;
            picture.Name = input.Name;
            picture.Price = input.Price;
            picture.Description = input.Description;
            picture.UserId = userId;

            var allowedExtensions = new[] { "jpg", "png", "gif" };
            Directory.CreateDirectory($"{imagePath}/pictures/");
            // /wwwroot/pictures/images/{id}.{ext}
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = Path.GetExtension(image.FileName),
                };

                picture.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/pictures/{dbImage.Id}.{extension}";

                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.picturesRepository.AddAsync(picture);
            await this.picturesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            var pictures = this.picturesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();

            return pictures;
        }

        public int GetCount()
        {
            return this.picturesRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            var recipe = this.picturesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return recipe;
        }
    }
}
