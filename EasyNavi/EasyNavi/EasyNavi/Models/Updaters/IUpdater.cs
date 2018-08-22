using EasyNavi.Core.DataObjects.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.Models.Updaters
{
    interface IUpdater
    {
        Task<bool> Update(JsonVersions jsonVersions, DataVersions dataVersions);
    }
}
