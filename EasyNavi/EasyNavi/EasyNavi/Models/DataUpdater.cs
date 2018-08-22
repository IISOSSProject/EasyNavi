using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Unity;
using System.IO;
using EasyNavi.Core.Models.Updaters;
using EasyNavi.Core.DataProviders;
using EasyNavi.Core.DataObjects.Entities;
using EasyNavi.Core.DataObjects.DataModels;

namespace EasyNavi.Core.Models
{
    public class DataUpdater : IDataUpdater
    {
        public async Task Update()
        {
            DataBaseHelper.CreateDataBase();

            var dataVersionsEntiry = DataBaseHelper.Select<DataVersionsEntity>(q => q.Take(1)).First();
            var jsonVersionsJson = await App.DIContainer.Resolve<ISourceDataProvider>().JsonDataVersions();
            var dataVersions = new DataVersions(dataVersionsEntiry);
            var jsonVersions = new JsonVersions(jsonVersionsJson);

            // コンテンツ
            await App.DIContainer.Resolve<IContentsUpdater>().Update(jsonVersions, dataVersions);

            foreach (var plugin in App.Plugins)
                await plugin.DataUpdate();
        }
    }
}
