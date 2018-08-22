using EasyNavi.Models.APIJsonModels.JsonModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders.HttpDataProviders
{
    public static class ContentSummariesDataProvider
    {
        public static async Task<JsonContentSummaries> Get() => await HttpDataProviderHelper.Get<JsonContentSummaries>(HttpDataProviderHelper.Act1204);
    }
}
