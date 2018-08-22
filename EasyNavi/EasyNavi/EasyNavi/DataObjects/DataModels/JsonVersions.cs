using EasyNavi.Models.APIJsonModels.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.DataObjects.DataModels
{
    class JsonVersions
    {
        public JsonDataVersions Json { get; }

        public long Contents { get; }

        public JsonVersions(JsonDataVersions strings)
        {
            Json = strings;

            Contents = long.TryParse(Json?.Contents, out var v) ? v : -1;
        }
    }
}
