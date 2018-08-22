using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels
{
    public class JsonCategoryLarge: IJsonCategoryLarge
    {
        [JsonProperty("Spot_Ctgr_L_Id")]
        public int ContentCategoryLargeId { get; set; }
        public string ContentCategoryLargeName { get; set; }
    }
}
