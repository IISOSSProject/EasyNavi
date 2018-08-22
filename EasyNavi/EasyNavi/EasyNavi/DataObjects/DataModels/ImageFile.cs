using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EasyNavi.Core.DataObjects.DataModels
{
    class ImageFile
    {
        public ImageFile(ImageSource image, bool hasImage) {
            ImageSource = image;
            HasImage = hasImage;
        }

        public ImageSource ImageSource { get; }
        public bool HasImage { get; }
    }
}
