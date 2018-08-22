using EasyNavi.Core.DataProviders;
using EasyNavi.Core.Models;
using EasyNavi.Core.Models.Updaters;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace EasyNavi.Core.SetUps
{
    internal static class SetUp
    {
        public static void Set()
        {
            SetDI();
            SetPlugins();
        }

        private static void SetDI()
        {
            App.DIContainer.RegisterInstance<IFileStrage>(new FileStrage());

            //App.DIContainer.RegisterInstance<ISourceDataProvider>(new SourceDataProvider());
            //App.DIContainer.RegisterInstance<ISourceDataProvider>(new LocalSourceDataProvider());
            App.DIContainer.RegisterInstance<ISourceDataProvider>(new LocalStrageDataProvider());
            //App.DIContainer.RegisterInstance<ISourceDataProvider>(new DownloadZipSourceDataProvider(
            //    App.DIContainer.Resolve<IFileStrage>()
            //    ));

            App.DIContainer.RegisterInstance<ILocalDataProvider>(new LocalDataProvider(
                App.DIContainer.Resolve<IFileStrage>()
            ));
            App.DIContainer.RegisterInstance<IDataUpdater>(new DataUpdater());
            App.DIContainer.RegisterInstance<IContentsUpdater>(new ContentsUpdater(
                App.DIContainer.Resolve<ISourceDataProvider>(),
                App.DIContainer.Resolve<ILocalDataProvider>()
            ));
        }

        private static void SetPlugins()
        {
            App.Plugins.Add(EasyNavi.Plugin.License.LicensePlugin.Instance);
        }
    }
}
