using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.DataObjects.Entities
{
    public class ContentSummaryEntity : IJsonContentSummary
    {
        [SQLite.PrimaryKey]
        public int Id { get => ContentId ?? 0; set => ContentId = value; }
        public string ContentCategoryLargeId { get; set; }
        public int? ContentId { get; set; }
        public string ContentName { get; set; }
        public string ContentDetail { get; set; }
        public double? ContentLatitude { get; set; }
        public double? ContentLongitude { get; set; }
        public double? ParkingLatitude { get; set; }
        public double? ParkingLongitude { get; set; }
        public string SctId { get; set; }
        public double? ViewFactor { get; set; }
        public string OpenFlag { get; set; }
        public string DeleteFlag { get; set; }
        public string ProcDiv { get; set; }
        public string TopFilename { get; set; }
    }
}
