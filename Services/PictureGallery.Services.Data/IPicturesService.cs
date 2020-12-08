namespace PictureGallery.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PictureGallery.Web.ViewModels.Pictures;

    public interface IPicturesService
    {
        Task CreateAsync(CreatePictureInputModel model, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6);

        int GetCount();

        T GetById<T>(int id);
    }
}
