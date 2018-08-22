using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace EasyNavi.Core.DataProviders.HttpDataProviders
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public sealed class HttpDataProviderHelperAttribute : Attribute
    {
        public string BaseUri { get; set; }
    }
}
