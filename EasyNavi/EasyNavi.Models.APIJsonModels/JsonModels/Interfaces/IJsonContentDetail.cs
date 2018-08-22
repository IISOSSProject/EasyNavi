using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels.Interfaces
{
    public interface IJsonContentDetail
    {
        int? ContentId { get; set; }
        string ContentName { get; set; }
        string ContentRead { get; set; }
        string ContentDetail { get; set; }
        string Zip { get; set; }
        string Address { get; set; }
        string ContactName { get; set; }
        string TelNo { get; set; }
        string OpenHour { get; set; }
        string Closed { get; set; }
        string Traffic { get; set; }
        string Parking { get; set; }
        string Rate { get; set; }
        string WebSiteUrl { get; set; }
        string YouTubeUrl { get; set; }
        double? ContentLatitude { get; set; }
        double? ContentLongitude { get; set; }
        double? ParkingLatitude { get; set; }
        double? ParkingLongitude { get; set; }
        string OpenFlag { get; set; }
        string DeleteFlag { get; set; }
        string ImageFlag { get; set; }
        string TopFilename { get; set; }
        string DetailFilename1 { get; set; }
        string DetailFilename2 { get; set; }
        string DetailFilename3 { get; set; }
        string DetailFilename4 { get; set; }
        string DetailFilename5 { get; set; }
    }
}
