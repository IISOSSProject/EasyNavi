using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels.Interfaces
{
    public interface IJsonContentSummary
    {
        string ContentCategoryLargeId { get; set; }
        int? ContentId { get; set; }
        string ContentName { get; set; }
        string ContentDetail { get; set; }
        double? ContentLatitude { get; set; }
        double? ContentLongitude { get; set; }
        double? ParkingLatitude { get; set; }
        double? ParkingLongitude { get; set; }
        string SctId { get; set; }
        double? ViewFactor { get; set; }
        string OpenFlag { get; set; }
        string DeleteFlag { get; set; }
        String ProcDiv { get; set; }
        string TopFilename { get; set; }
    }
}
