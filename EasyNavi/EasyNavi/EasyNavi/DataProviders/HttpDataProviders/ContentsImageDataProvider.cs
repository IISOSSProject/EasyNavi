using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders.HttpDataProviders
{
    static class ContentsImageDataProvider
    {
        public static async Task<byte[]> Get() => await HttpDataProviderHelper.GetByteArray(HttpDataProviderHelper.Act1105);
    }
}
