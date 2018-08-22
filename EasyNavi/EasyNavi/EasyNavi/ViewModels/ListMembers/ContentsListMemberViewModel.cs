using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EasyNavi.Core.ViewModels.ListMembers
{
    class ContentsListMemberViewModel
    {
        public ContentsListMemberViewModel(ImageSource icon, int? contentId, string title, string detail)
        {
            Icon = icon;
            ContentId = contentId;
            Title = title;
            Detail = detail;
        }
        public ImageSource Icon { get; set; }
        public int? ContentId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
