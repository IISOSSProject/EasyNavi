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
    public partial class ContentsView : ContentPage
    {
        public ContentsView() => InitializeComponent();

        private void ContentsView_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<ContentsViewModel>(this, ContentsViewModel.Messages.GoContentView, GoContentsView);

            ((ContentsViewModel)this.BindingContext).AppearingCommand?.Execute(null);
        }

        private void ContentsView_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<ContentsViewModel>(this, ContentsViewModel.Messages.GoContentView);
        }

        private void GoContentsView<T>(T sender) => Navigation.PushModalAsync(new Views.Contents.ContentView());

        private void Back_Tapped(object sender, EventArgs e) => Navigation.PopModalAsync();

        private void List_ItemSelected(object sender, EventArgs e)
        {
            var selected = listView.SelectedItem;
            if (selected == null) return;
            listView.SelectedItem = null;
            ((ContentsViewModel)this.BindingContext).SelectedCommand?.Execute(selected);
        }

    }
}