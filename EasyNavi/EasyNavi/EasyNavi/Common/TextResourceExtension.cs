using EasyNavi.Core.Resources.Texts;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyNavi.Core.Common
{
    [ContentProperty("Source")]
    internal class TextResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null) return null;
            return ResourceTexts.FromName(Source);
        }
    }
}
