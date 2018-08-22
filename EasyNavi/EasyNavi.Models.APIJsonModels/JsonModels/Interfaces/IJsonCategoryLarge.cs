using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Models.APIJsonModels.JsonModels.Interfaces
{
    public interface IJsonCategoryLarge
    {
        int ContentCategoryLargeId { get; set; }
        string ContentCategoryLargeName { get; set; }
    }
}
