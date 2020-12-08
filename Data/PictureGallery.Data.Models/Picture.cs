namespace PictureGallery.Data.Models
{
    using System.Collections.Generic;

    using PictureGallery.Data.Common.Models;

    public class Picture : BaseDeletableModel<int>
    {
        public Picture()
        {
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsOriginal { get; set; }

        public bool IsPrint { get; set; }

        public bool IsAvailable { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images{ get; set; }
    }
}
