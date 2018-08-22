using EasyNavi.Core.Common;
using EasyNavi.Core.DataProviders.HttpDataProviders;
using EasyNavi.Core.Models;
using EasyNavi.Models.APIJsonModels.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders
{
    class DownloadZipSourceDataProvider : ISourceDataProvider
    {
        private IFileStrage _fileStrage = null;
        private FileInfo _contentsDataFile = null;

        public DownloadZipSourceDataProvider(IFileStrage fileStrage)
        {
            this._fileStrage = fileStrage;
            this._contentsDataFile = _fileStrage.ContentsDataFile;
            fileStrage.InitializeStorage();
        }

        public async Task<byte[]> Images() => await ZipFileHelper.ReadBytesFromFile(_contentsDataFile, "images.zip");

        public async Task<byte[]> Images(int? contentId) => await ZipFileHelper.ReadBytesFromFile(_contentsDataFile, $"images_{contentId}.zip");

        public async Task<JsonContentDetail> JsonContentDetail(int? contentId)
        {
            var text = await ZipFileHelper.ReadStringFromFile(_contentsDataFile, $"detail_{contentId}.json");
            return JsonConvert.DeserializeObject<JsonContentDetail>(text);
        }

        public async Task<JsonContentSummaries> JsonContentSummaries()
        {
            var text = await ZipFileHelper.ReadStringFromFile(_contentsDataFile, "summaries.json");
            return JsonConvert.DeserializeObject<JsonContentSummaries>(text);
        }

        public async Task<IEnumerable<(JsonContentSummary summary, JsonContentDetail detail)>> JsonContentSummariesAndDetails()
        {
            _fileStrage.WriteAllBytes(_contentsDataFile, await HttpDataProviderHelper.GetByteArray(HttpDataProviderHelper.Uri(code:"ContentsData.zip")));

            var q = new Queue<(JsonContentSummary, JsonContentDetail)>();
            var summaries = await JsonContentSummaries();
            foreach (var summary in summaries?.ContentSummaries)
            {
                if (string.IsNullOrEmpty(summary.ContentCategoryLargeId)) summary.ContentCategoryLargeId = summary.ContentCategoryLargeList?.Select(c => c.ContentCategoryLargeId.ToString()).FirstOrDefault();
                q.Enqueue((summary, await JsonContentDetail(summary.ContentId)));
            }
            return q.ToArray();
        }

        public async Task<JsonDataVersions> JsonDataVersions() => await HttpDataProviderHelper.Get<JsonDataVersions>(HttpDataProviderHelper.Uri(code:"Versions.json"));
    }
}
