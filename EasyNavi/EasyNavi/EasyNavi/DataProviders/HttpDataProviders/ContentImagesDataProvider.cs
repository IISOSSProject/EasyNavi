using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders.HttpDataProviders
{
    static class ContentImagesDataProvider
    {
        public static async Task<byte[]> Get(int? contentId) => await HttpDataProviderHelper.GetByteArray(HttpDataProviderHelper.Act1107(contentId));
    }
}
