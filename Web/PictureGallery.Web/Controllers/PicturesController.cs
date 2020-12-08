namespace PictureGallery.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PictureGallery.Data;
    using PictureGallery.Data.Common.Repositories;
    using PictureGallery.Data.Models;
    using PictureGallery.Services.Data;
    using PictureGallery.Web.ViewModels;
    using PictureGallery.Web.ViewModels.Home;
    using PictureGallery.Web.ViewModels.Pictures;

    public class PicturesController : Controller
    {
        private readonly IPicturesService picturesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICategoriesService categoriesService;
        private readonly IWebHostEnvironment environment;

        public PicturesController(
            IPicturesService picturesService,
            UserManager<ApplicationUser> userManager,
            ICategoriesService categoriesService,
            IWebHostEnvironment environment)
        {
            this.picturesService = picturesService;
            this.userManager = userManager;
            this.categoriesService = categoriesService;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePictureInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuepairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePictureInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoriesService.GetAllAsKeyValuepairs();
                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            /* userId through cookie
             var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value; */
            try
            {
                await this.picturesService.CreateAsync(model, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new PictureListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                PicturesCount = this.picturesService.GetCount(),
                Pictures = this.picturesService.GetAll<PictureInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }
    }
}
