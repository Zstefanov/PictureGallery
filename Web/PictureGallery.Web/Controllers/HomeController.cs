namespace PictureGallery.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PictureGallery.Data;
    using PictureGallery.Data.Common.Repositories;
    using PictureGallery.Data.Models;
    using PictureGallery.Web.ViewModels;
    using PictureGallery.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Picture> picturesRepository;

        public HomeController(
            IDeletableEntityRepository<Picture> picturesRepository)
        {
            this.picturesRepository = picturesRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                PicturesCount = this.picturesRepository.All().Count(),
                AvailablePicture = this.picturesRepository.All().Where(x => x.IsAvailable == true).Count(),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
