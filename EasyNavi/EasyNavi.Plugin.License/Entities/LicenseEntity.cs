using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Plugin.License.Entities
{
    class LicenseEntity
    {
        [SQLite.PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
    }
}
