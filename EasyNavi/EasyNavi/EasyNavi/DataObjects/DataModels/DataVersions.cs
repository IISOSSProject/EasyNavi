using EasyNavi.Core.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.DataObjects.DataModels
{
    class DataVersions
    {
        public DataVersionsEntity Entity { get; }

        public long Contents { get; }

        public DataVersions(DataVersionsEntity strings)
        {
            Entity = strings;

            Contents = long.TryParse(Entity?.Contents, out var v) ? v : -1;
        }
    }
}
