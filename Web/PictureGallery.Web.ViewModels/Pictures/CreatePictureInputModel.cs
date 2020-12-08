
namespace PictureGallery.Web.ViewModels.Pictures
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using PictureGallery.Data.Models;

    public class CreatePictureInputModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public string Size { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool IsOriginal { get; set; }

        public bool IsPrint { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public string CategoryId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Artist")]
        public virtual ApplicationUser User { get; set; }
    }
}
