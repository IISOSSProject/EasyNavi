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
    public partial class ContentsCategoriesView : ContentPage
    {
        public ContentsCategoriesView() => InitializeComponent();

        private void ContentsCategoriesView_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<ContentsCategoriesViewModel>(this, ContentsCategoriesViewModel.Messages.GoContentsView, GoContentsView);

            ((ContentsCategoriesViewModel)this.BindingContext).AppearingCommand?.Execute(null);
        }

        private void ContentsCategoriesView_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<ContentsCategoriesViewModel>(this, ContentsCategoriesViewModel.Messages.GoContentsView);
        }

        private void GoContentsView<T>(T sender) => Navigation.PushModalAsync(new Views.Contents.ContentsView());

        private void Back_Tapped(object sender, EventArgs e) => Navigation.PopModalAsync();

        private void List_ItemSelected(object sender, EventArgs e)
        {
            var selected = listView.SelectedItem;
            if (selected == null) return;
            listView.SelectedItem = null;
            ((ContentsCategoriesViewModel)this.BindingContext).SelectedCommand?.Execute(selected);
        }
    }
}