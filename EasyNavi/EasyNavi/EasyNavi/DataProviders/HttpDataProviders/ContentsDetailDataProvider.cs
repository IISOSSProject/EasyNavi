using EasyNavi.Models.APIJsonModels.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders.HttpDataProviders
{
    public static class ContentsDetailDataProvider
    {
        public static async Task<JsonContentDetail> Get(int? contentId) => await HttpDataProviderHelper.Get<JsonContentDetail>(HttpDataProviderHelper.Act1206(contentId));
    }
}
