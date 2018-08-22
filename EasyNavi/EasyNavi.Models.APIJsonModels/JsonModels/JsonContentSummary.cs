using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels
{
    public class JsonContentSummary: IJsonContentSummary
    {
        [JsonProperty("Spot_Ctgr_Large_Id")]
        public string ContentCategoryLargeId { get; set; }
        [JsonProperty("Spot_Cnts_Id")]
        public int? ContentId { get; set; }
        [JsonProperty("Spot_Name")]
        public string ContentName { get; set; }
        [JsonProperty("Spot_Detail")]
        public string ContentDetail { get; set; }
        [JsonProperty("Spot_Lat")]
        public double? ContentLatitude { get; set; }
        [JsonProperty("Spot_Lng")]
        public double? ContentLongitude { get; set; }
        [JsonProperty("Parking_Lat")]
        public double? ParkingLatitude { get; set; }
        [JsonProperty("Parking_Lng")]
        public double? ParkingLongitude { get; set; }
        [JsonProperty("Sct_Id")]
        public string SctId { get; set; }
        [JsonProperty("View_Factor")]
        public double? ViewFactor { get; set; }
        [JsonProperty("Open_Flg")]
        public string OpenFlag { get; set; }
        [JsonProperty("Spot_Ctgr_L_List")]
        public List<JsonCategoryLarge> ContentCategoryLargeList { get; set; }
        [JsonProperty("Del_Flg")]
        public string DeleteFlag { get; set; }
        [JsonProperty("Proc_Div")]
        public String ProcDiv { get; set; }
        [JsonProperty("Top_Filename")]
        public string TopFilename { get; set; }
    }
}
