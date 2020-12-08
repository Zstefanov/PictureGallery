namespace PictureGallery.Web.ViewModels.Pictures
{
    using System.Linq;

    using AutoMapper;
    using PictureGallery.Data.Models;
    using PictureGallery.Services.Mapping;

    public class PictureInListViewModel : IMapFrom<Picture> /*IHaveCustomMappings*/
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Picture, PictureInListViewModel>()
        //        .ForMember(x => x.ImageUrl, opt =>
        //          opt.MapFrom(x =>
        //          x.Images.FirstOrDefault().RemoteImageUrl != null ?
        //          x.Images.FirstOrDefault().RemoteImageUrl :
        //          "/images/pictures/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        //}
    }
}
