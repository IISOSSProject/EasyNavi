using EasyNavi.Core.DataObjects;
using EasyNavi.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyNavi.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuView : ContentPage
    {
        public MainMenuView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void MainMenuView_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<DisplayAlertParameter>(this, DisplayAlertParameter.Messages.DisplayAlert, DisplayAlert);
            MessagingCenter.Subscribe<MainMenuViewModel>(this, MainMenuViewModel.Messages.GoContentsView, GoContentsView);
            MessagingCenter.Subscribe<MainMenuViewModel>(this, MainMenuViewModel.Messages.GoWebSitesView, GoWebSitesView);

            await ((MainMenuViewModel)this.BindingContext).DataUpdate();
        }

        private void MainMenuView_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<DisplayAlertParameter>(this, DisplayAlertParameter.Messages.DisplayAlert);
            MessagingCenter.Unsubscribe<MainMenuViewModel>(this, MainMenuViewModel.Messages.GoContentsView);
            MessagingCenter.Unsubscribe<MainMenuViewModel>(this, MainMenuViewModel.Messages.GoWebSitesView);
        }

        private async void DisplayAlert(DisplayAlertParameter sender)
        {
            var result = false;
            if (string.IsNullOrEmpty(sender?.Accept))
                await DisplayAlert(sender?.Title, sender?.Message, sender?.Cancel);
            else
                result = await DisplayAlert(sender?.Title, sender?.Message, sender?.Accept, sender?.Cancel);
            sender?.Action?.Invoke(result);
        }

        private void GoContentsView<T>(T sender) => Navigation.PushModalAsync(new Views.Contents.ContentsCategoriesView());

        private void GoWebSitesView<T>(T sender) => Navigation.PushModalAsync(new Views.WebSites.WebSiteView());


        // Plugins
        private void License_Clicked(object sender, EventArgs e) => Navigation.PushModalAsync(new EasyNavi.Plugin.License.Views.LicensesPage());
    }
}