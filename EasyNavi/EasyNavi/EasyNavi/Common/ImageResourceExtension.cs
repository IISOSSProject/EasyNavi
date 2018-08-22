using EasyNavi.Core.Resources.Images;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyNavi.Core.Common
{
    [ContentProperty("Source")]
    internal class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null) return null;
            return ResourceImages.PngFromName(Source);
        }
    }
}
