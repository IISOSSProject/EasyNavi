using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.DataObjects.Entities
{
    public class DataVersionsEntity : IJsonDataVersions
    {
        [SQLite.PrimaryKey]
        public int Id { get; set; } = 1;
        public string Contents { get; set; }
    }
}
