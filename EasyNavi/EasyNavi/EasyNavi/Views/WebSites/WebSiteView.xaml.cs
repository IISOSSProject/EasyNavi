using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyNavi.Core.Views.WebSites
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebSiteView : ContentPage
    {
        public WebSiteView() => InitializeComponent();

        private void WebSiteView_Navigated(object sender, WebNavigatedEventArgs e) => url.Text = e.Url;

        private void Back_Tapped(object sender, EventArgs e) => OnBack();

        protected override bool OnBackButtonPressed()
        {
            OnBack();
            return true;
        }

        private void OnBack()
        {
            webView.Source = "about:blank";
            Navigation.PopModalAsync();
        }
    }
}