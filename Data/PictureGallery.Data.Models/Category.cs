namespace PictureGallery.Data.Models
{
    using System.Collections.Generic;

    using PictureGallery.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Pictures = new HashSet<Picture>();
        }

        public string Name { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
