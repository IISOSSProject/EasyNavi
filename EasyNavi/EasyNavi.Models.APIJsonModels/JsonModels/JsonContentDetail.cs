using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels
{
    public class JsonContentDetail: IJsonContentDetail
    {
        [JsonProperty("Spot_Cnts_Id")]
        public int? ContentId { get; set; }
        [JsonProperty("Spot_Name")]
        public string ContentName { get; set; }
        [JsonProperty("Spot_Read")]
        public string ContentRead { get; set; }
        [JsonProperty("Spot_Detail")]
        public string ContentDetail { get; set; }
        [JsonProperty("Zip")]
        public string Zip { get; set; }
        [JsonProperty("Adrs")]
        public string Address { get; set; }
        [JsonProperty("Contacts_Name")]
        public string ContactName { get; set; }
        [JsonProperty("Tel_No")]
        public string TelNo { get; set; }
        [JsonProperty("Open_Hour")]
        public string OpenHour { get; set; }
        [JsonProperty("Closed")]
        public string Closed { get; set; }
        [JsonProperty("Traffic")]
        public string Traffic { get; set; }
        [JsonProperty("Parking")]
        public string Parking { get; set; }
        [JsonProperty("Rate")]
        public string Rate { get; set; }
        [JsonProperty("Hp_Url")]
        public string WebSiteUrl { get; set; }
        [JsonProperty("Yt_Url")]
        public string YouTubeUrl { get; set; }
        [JsonProperty("Spot_Lat")]
        public double? ContentLatitude { get; set; }
        [JsonProperty("Spot_Lng")]
        public double? ContentLongitude { get; set; }
        [JsonProperty("Parking_Lat")]
        public double? ParkingLatitude { get; set; }
        [JsonProperty("Parking_Lng")]
        public double? ParkingLongitude { get; set; }
        [JsonProperty("Open_Flg")]
        public string OpenFlag { get; set; }
        [JsonProperty("Del_Flg")]
        public string DeleteFlag { get; set; }
        [JsonProperty("Img_Flg")]
        public string ImageFlag { get; set; }
        [JsonProperty("Top_Filename")]
        public string TopFilename { get; set; }
        [JsonProperty("Detail_Filename1")]
        public string DetailFilename1 { get; set; }
        [JsonProperty("Detail_Filename2")]
        public string DetailFilename2 { get; set; }
        [JsonProperty("Detail_Filename3")]
        public string DetailFilename3 { get; set; }
        [JsonProperty("Detail_Filename4")]
        public string DetailFilename4 { get; set; }
        [JsonProperty("Detail_Filename5")]
        public string DetailFilename5 { get; set; }
    }
}
