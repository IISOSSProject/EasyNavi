using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EasyNavi.Models.APIJsonModels.JsonModels;

namespace EasyNavi.Core.DataProviders
{
    class SourceDataProvider : ISourceDataProvider
    {
        public async Task<byte[]> Images() => await DataProviders.HttpDataProviders.ContentsImageDataProvider.Get();

        public async Task<byte[]> Images(int? contentId) => await DataProviders.HttpDataProviders.ContentImagesDataProvider.Get(contentId);

        public async Task<JsonContentDetail> JsonContentDetail(int? contentId) => await DataProviders.HttpDataProviders.ContentsDetailDataProvider.Get(contentId);

        public async Task<JsonContentSummaries> JsonContentSummaries() => await DataProviders.HttpDataProviders.ContentSummariesDataProvider.Get();

        public async Task<IEnumerable<(JsonContentSummary, JsonContentDetail)>> JsonContentSummariesAndDetails()
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

        public async Task<JsonDataVersions> JsonDataVersions() => await DataProviders.HttpDataProviders.DataVersionsDataProvider.Get();
    }
}
