using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.DataObjects.Entities
{
    public class ContentDetailEntity : IJsonContentDetail
    {
        [SQLite.PrimaryKey]
        public int Id { get => ContentId ?? 0; set => ContentId = value; }
        public int? ContentId { get; set; }
        public string ContentName { get; set; }
        public string ContentRead { get; set; }
        public string ContentDetail { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string TelNo { get; set; }
        public string OpenHour { get; set; }
        public string Closed { get; set; }
        public string Traffic { get; set; }
        public string Parking { get; set; }
        public string Rate { get; set; }
        public string WebSiteUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public double? ContentLatitude { get; set; }
        public double? ContentLongitude { get; set; }
        public double? ParkingLatitude { get; set; }
        public double? ParkingLongitude { get; set; }
        public string OpenFlag { get; set; }
        public string DeleteFlag { get; set; }
        public string ImageFlag { get; set; }
        public string TopFilename { get; set; }
        public string DetailFilename1 { get; set; }
        public string DetailFilename2 { get; set; }
        public string DetailFilename3 { get; set; }
        public string DetailFilename4 { get; set; }
        public string DetailFilename5 { get; set; }
    }
}
