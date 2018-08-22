using EasyNavi.Core.Common;
using EasyNavi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Unity;
using EasyNavi.Core.DataObjects;

namespace EasyNavi.Core.ViewModels
{
    class MainMenuViewModel : BindableBase
    {
        private bool _isFirst = true;

        private bool _isDataUpdating;
        public bool IsDataUpdating { get => _isDataUpdating; private set => SetProperty(ref _isDataUpdating, value); }

        public Command GoContentsViewCommand { get; }
        public Command GoWebSitesViewCommand { get; }
        public Command GoWebSites2ViewCommand { get; }
        public Command GoWebSites3ViewCommand { get; }
        public Command GoWebSites4ViewCommand { get; }

        public MainMenuViewModel()
        {
            GoContentsViewCommand = new Command(() => MessagingCenter.Send(this, Messages.GoContentsView));
            GoWebSitesViewCommand = new Command(() =>
            {
                WebSites.WebSiteViewModel.InitialData = WebSites.WebSiteViewModel.InitialDataModel.FromUrlAndTitle("http://iis.image-inf.co.jp/sid/", "オフィシャルサイト");
                MessagingCenter.Send(this, Messages.GoWebSitesView);
            });
            GoWebSites2ViewCommand = new Command(() =>
            {
                WebSites.WebSiteViewModel.InitialData = WebSites.WebSiteViewModel.InitialDataModel.FromUrlAndTitle("http://iis.image-inf.co.jp/sid/", "オフィシャルサイト");
                MessagingCenter.Send(this, Messages.GoWebSitesView);
            });
            GoWebSites3ViewCommand = new Command(() =>
            {
                WebSites.WebSiteViewModel.InitialData = WebSites.WebSiteViewModel.InitialDataModel.FromUrlAndTitle("http://iis.image-inf.co.jp/sid/", "オフィシャルサイト");
                MessagingCenter.Send(this, Messages.GoWebSitesView);
            });
            GoWebSites4ViewCommand = new Command(() =>
            {
                WebSites.WebSiteViewModel.InitialData = WebSites.WebSiteViewModel.InitialDataModel.FromUrlAndTitle("http://iis.image-inf.co.jp/sid/", "オフィシャルサイト");
                MessagingCenter.Send(this, Messages.GoWebSitesView);
            });
        }

        public async Task DataUpdate()
        {
            if (!_isFirst) return;
            _isFirst = false;

            await InitializePlugins();

            IsDataUpdating = true;
            await PrivateDataUpdate(true);
        }

        private async Task InitializePlugins()
        {
            var assem = typeof(App).Assembly;
            Func<SQLite.SQLiteConnection> factory = DataBaseHelper.CreateConnection;
            var path = App.DIContainer.Resolve<IFileStrage>();

            foreach(var plugin in App.Plugins)
            {
                plugin.RegistAppAssembly(assem);
                plugin.RegistDataBaseConnectionFactory(factory);
                plugin.RegistFileStragePath(path);
                await plugin.Init();
            }
        }

        private async Task PrivateDataUpdate(bool isTry)
        {
            if (!isTry)
            {
                IsDataUpdating = false;
                return;
            }

            IsDataUpdating = true;
            try
            {
                await App.DIContainer.Resolve<IDataUpdater>().Update();
                IsDataUpdating = false;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                MessagingCenter.Send(new DisplayAlertParameter("データ更新", "エラーが発生しました。", "リトライ", "キャンセル", PrivateDataUpdate), DisplayAlertParameter.Messages.DisplayAlert);
            }
        }

        public static class Messages
        {
            public static string GoContentsView { get; } = nameof(GoContentsView);
            public static string GoWebSitesView { get; } = nameof(GoWebSitesView);
        }
    }
}
