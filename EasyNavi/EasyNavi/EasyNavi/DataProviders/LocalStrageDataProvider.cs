using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using EasyNavi.Core.Common;
using EasyNavi.Models.APIJsonModels.JsonModels;

namespace EasyNavi.Core.DataProviders
{
    public class LocalStrageDataProvider : ISourceDataProvider
    {
        public static string ExternalStorage { get; set; }

        static string LocalSourceDataPath { get { return ExternalStorage + "/" + "EasyNavi/Core/Resources/LocalSourceData/"; } }
        static string LocalSourceDataFile { get{ return $"{LocalSourceDataPath}ContentsData.zip"; } }
        Type _appType = typeof(App);
        Assembly _assembly = typeof(App).Assembly;

        public async Task<byte[]> Images() => await ZipFileHelper.ReadBytesFromFile(new FileInfo(LocalSourceDataFile), "images.zip");

        public async Task<byte[]> Images(int? contentId) => await ZipFileHelper.ReadBytesFromFile(new FileInfo(LocalSourceDataFile), $"images_{contentId}.zip");

        public async Task<JsonContentDetail> JsonContentDetail(int? contentId)
        {
            var text = await ZipFileHelper.ReadStringFromFile(new FileInfo(LocalSourceDataFile), $"detail_{contentId}.json");
            return JsonConvert.DeserializeObject<JsonContentDetail>(text);
        }

        public async Task<JsonContentSummaries> JsonContentSummaries()
        {
            var text = await ZipFileHelper.ReadStringFromFile(new FileInfo(LocalSourceDataFile), "summaries.json");
            return JsonConvert.DeserializeObject<JsonContentSummaries>(text);
        }

        public async Task<IEnumerable<(JsonContentSummary summary, JsonContentDetail detail)>> JsonContentSummariesAndDetails()
        {
            var q = new Queue<(JsonContentSummary, JsonContentDetail)>();
            var summaries = await JsonContentSummaries();
            foreach (var summary in summaries?.ContentSummaries)
            {
                if (string.IsNullOrEmpty(summary.ContentCategoryLargeId)) summary.ContentCategoryLargeId = summary.ContentCategoryLargeList?.Select(c => c.ContentCategoryLargeId.ToString()).FirstOrDefault();
                q.Enqueue((summary, await JsonContentDetail(summary.ContentId)));
            }
            return q.ToArray();
        }

        public async Task<JsonDataVersions> JsonDataVersions()
        {
            using (var stream = new FileInfo($"{LocalSourceDataPath}Versions.json").OpenRead())
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<JsonDataVersions>(await reader.ReadToEndAsync());
        }
    }
}
