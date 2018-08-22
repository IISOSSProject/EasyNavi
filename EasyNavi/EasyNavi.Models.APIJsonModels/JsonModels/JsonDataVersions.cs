using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels
{
    public class JsonDataVersions: IJsonDataVersions
    {
        [JsonProperty("spot_ver")]
        public string Contents { get; set; }
    }
}
