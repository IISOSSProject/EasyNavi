using EasyNavi.Core.ViewModels.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyNavi.Core.Views.Contents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentView : ContentPage
    {
        public ContentView() => InitializeComponent();

        private void ContentView_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<ContentViewModel>(this, ContentViewModel.Messages.GoWebSiteView, GoWebSiteView);

            ((ContentViewModel)this.BindingContext).AppearingCommand?.Execute(null);
        }

        private void ContentView_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<ContentViewModel>(this, ContentViewModel.Messages.GoWebSiteView);
        }

        private void Back_Tapped(object sender, EventArgs e) => Navigation.PopModalAsync();

        private void GoWebSiteView<T>(T sender) => Navigation.PushModalAsync(new Views.WebSites.WebSiteView());
    }
}