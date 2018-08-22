using EasyNavi.Core.Common;
using EasyNavi.Core.DataProviders;
using EasyNavi.Core.ViewModels.ListMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Unity;

namespace EasyNavi.Core.ViewModels.Contents
{
    class ContentsCategoriesViewModel : BindableBase
    {
        private bool _isFirst = true;

        private string _searchText;
        public string SearchText { get => _searchText; set => SetProperty(ref _searchText, value); }

        private IEnumerable<ContentsCategoriesListMemberViewModel> _items;
        public IEnumerable<ContentsCategoriesListMemberViewModel> Items { get => _items; private set => SetProperty(ref _items, value); }

        public Command AppearingCommand { get; }
        public Command SearchCommand { get; }
        public Command SelectedCommand { get; }

        public ContentsCategoriesViewModel()
        {
            AppearingCommand = new Command(Appearing);
            SearchCommand = new Command(Search);
            SelectedCommand = new Command(Selected);
        }

        private async void Appearing()
        {
            if (!_isFirst) return;
            _isFirst = false;

            var dataProvider = App.DIContainer.Resolve<ILocalDataProvider>();

            ContentsCategoriesListMemberViewModel[] data = null;
            await Task.Run(() =>
            {
                data = dataProvider.ContentCategory().Select(c => new ContentsCategoriesListMemberViewModel(c.Image, c.Id, c.Name)).ToArray();
            });
            Items = data;
        }

        private void Search()
        {
            ContentsViewModel.InitialData = ContentsViewModel.InitialDataModel.FromSearchText(SearchText);
            MessagingCenter.Send(this, Messages.GoContentsView);
        }

        private void Selected(object selected)
        {
            var item = selected as ContentsCategoriesListMemberViewModel;
            if (item == null) return;

            ContentsViewModel.InitialData = ContentsViewModel.InitialDataModel.FromCategoryId(item.ContentCategoryLargeId, item.CategoryName);
            MessagingCenter.Send(this, Messages.GoContentsView);
        }

        public static class Messages
        {
            public static string GoContentsView { get; } = nameof(GoContentsView);
        }
    }
}
