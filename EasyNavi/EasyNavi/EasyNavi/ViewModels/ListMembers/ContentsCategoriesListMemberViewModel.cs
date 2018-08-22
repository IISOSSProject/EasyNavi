using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EasyNavi.Core.ViewModels.ListMembers
{
    class ContentsCategoriesListMemberViewModel
    {
        public ContentsCategoriesListMemberViewModel() {; }
        public ContentsCategoriesListMemberViewModel(ImageSource icon, int? contentCategoryLargeId, string categoryName)
        {
            Icon = icon;
            ContentCategoryLargeId = contentCategoryLargeId;
            CategoryName = categoryName;
        }

        public ImageSource Icon { get; set; }
        public int? ContentCategoryLargeId { get; set; }
        public string CategoryName { get; set; }
    }
}
