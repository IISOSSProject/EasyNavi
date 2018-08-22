using EasyNavi.Models.APIJsonModels.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders.HttpDataProviders
{
    public static class DataVersionsDataProvider
    {
        public static async Task<JsonDataVersions> Get() => await HttpDataProviderHelper.Get<JsonDataVersions>(HttpDataProviderHelper.Act1402);
    }
}
