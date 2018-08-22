using EasyNavi.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.ViewModels.WebSites
{
    class WebSiteViewModel : BindableBase
    {
        public static InitialDataModel InitialData { get; set; }

        private string _uri;
        public string Uri { get => _uri; set => SetProperty(ref _uri, value); }
        private string _title;
        public string Title { get => _title; set => SetProperty(ref _title, value); }

        public WebSiteViewModel()
        {
            if (!string.IsNullOrEmpty(InitialData?.Url)) Uri = InitialData?.Url;
            if (!string.IsNullOrEmpty(InitialData?.Title)) Title = InitialData?.Title;
        }

        public class InitialDataModel
        {
            public string Url { get; set; }
            public string Title { get; set; }

            public static InitialDataModel FromUrlAndTitle(string url, string title) => new InitialDataModel { Url = url, Title = title };
        }
    }
}
