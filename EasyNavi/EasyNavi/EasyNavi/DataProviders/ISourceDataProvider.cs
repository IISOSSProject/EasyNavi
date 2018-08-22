using EasyNavi.Models.APIJsonModels.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataProviders
{
    interface ISourceDataProvider
    {
        Task<JsonDataVersions> JsonDataVersions();
        Task<JsonContentSummaries> JsonContentSummaries();
        Task<JsonContentDetail> JsonContentDetail(int? contentId);
        Task<IEnumerable<(JsonContentSummary summary, JsonContentDetail detail)>> JsonContentSummariesAndDetails();
        Task<byte[]> Images();
        Task<byte[]> Images(int? contentId);
    }
}
