using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders.HttpDataProviders
{
    public static class HttpDataProviderHelper
    {
        public static async Task<T> Get<T>(Uri uri) => JsonConvert.DeserializeObject<T>(await new HttpClient().GetStringAsync(uri));
        public static async Task<byte[]> GetByteArray(Uri uri) => await new HttpClient().GetByteArrayAsync(uri);

        private static string _baseUrl;

        private static string BaseUrl => _baseUrl ?? (_baseUrl = Assembly.GetAssembly(typeof(HttpDataProviderHelper)).GetCustomAttribute<HttpDataProviderHelperAttribute>()?.BaseUri);

        public static Uri Uri(int? contentId =null, [CallerMemberName]string code = null) => new Uri(string.Format(BaseUrl, code?.Replace("Act", "s"), contentId));

        public static Uri Act1204 => Uri();

        public static Uri Act1402 => Uri();
        public static Uri Act1206(int? contentId) => Uri(contentId);
        public static Uri Act1107(int? contentId) => Uri(contentId);
        public static Uri Act1105 => Uri();
    }
}
