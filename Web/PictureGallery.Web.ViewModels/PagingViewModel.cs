namespace PictureGallery.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPagenumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.PicturesCount / this.ItemsPerPage);

        public int PicturesCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
