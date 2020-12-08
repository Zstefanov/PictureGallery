namespace PictureGallery.Web.ViewModels.Pictures
{
    using System;
    using System.Collections.Generic;

    public class PictureListViewModel : PagingViewModel
    {
        public IEnumerable<PictureInListViewModel> Pictures { get; set; }
    }
}
