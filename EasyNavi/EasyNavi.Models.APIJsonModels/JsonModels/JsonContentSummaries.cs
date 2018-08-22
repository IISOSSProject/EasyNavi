using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels
{
    public class JsonContentSummaries: IJsonContentSummaries
    {
        [JsonProperty("Response")]
        public List<JsonContentSummary> ContentSummaries { get; set; }
    }
}
