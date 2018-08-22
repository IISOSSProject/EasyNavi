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
    class ContentsViewModel : BindableBase
    {
        private bool _isFirst = true;

        public static InitialDataModel InitialData { get; set; }


        private string _categoryName;
        public string CategoryName { get => _categoryName; set => SetProperty(ref _categoryName, value); }
        private string _searchText;
        public string SearchText { get => _searchText; set => SetProperty(ref _searchText, value); }

        private IEnumerable<ContentsListMemberViewModel> _items;
        public IEnumerable<ContentsListMemberViewModel> Items { get => _items; private set => SetProperty(ref _items, value); }


        public Command AppearingCommand { get; }
        public Command SearchCommand { get; }
        public Command SelectedCommand { get; }


        public ContentsViewModel()
        {
            AppearingCommand = new Command(Appearing);
            SearchCommand = new Command(async () => await Search());
            SelectedCommand = new Command(Selected);

            CategoryName = InitialData?.ContentCategoryLargeName ?? InitialData?.SearchText;
            SearchText = InitialData?.SearchText;
        }

        private async void Appearing()
        {
            if (!_isFirst) return;
            _isFirst = false;

            await Search();
        }

        private async Task Search()
        {
            var dataProvider = App.DIContainer.Resolve<ILocalDataProvider>();

            ContentsListMemberViewModel[] data = null;
            await Task.Run(() =>
            {
                var categoryId = InitialData?.ContentCategoryLargeId?.ToString();
                var searchText = SearchText;
                var parentText = InitialData?.SearchText;

                data = dataProvider.Contents(categoryId, new[] { searchText, parentText }).Select(d => new ContentsListMemberViewModel(d.Image, d.Id, d.Name, d.Detail)).ToArray();
            });
            Items = data;
        }

        private void Selected(object selected)
        {
            var item = selected as ContentsListMemberViewModel;
            if (item == null) return;

            ContentViewModel.InitialData = ContentViewModel.InitialDataModel.FromContentId(item.ContentId);
            MessagingCenter.Send(this, Messages.GoContentView);
        }

        public class InitialDataModel
        {
            public string SearchText { get; set; }
            public int? ContentCategoryLargeId { get; set; }
            public string ContentCategoryLargeName { get; set; }

            public static InitialDataModel FromSearchText(string text) => new InitialDataModel { SearchText = text };
            public static InitialDataModel FromCategoryId(int? id, string name) => new InitialDataModel { ContentCategoryLargeId = id, ContentCategoryLargeName = name };
        }

        public static class Messages
        {
            public static string GoContentView { get; } = nameof(GoContentView);
        }
    }
}
