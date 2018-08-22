using EasyNavi.Core.DataObjects.DataModels;
using EasyNavi.Core.Models;
using EasyNavi.Core.Resources.Images;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace EasyNavi.Core.DataProviders.StrageDataProviders
{
    class ContentImageDataProvider
    {
        private IFileStrage _fileStrage;
        public ContentImageDataProvider(IFileStrage fileStrage) => _fileStrage = fileStrage;

        public ImageFile ImageFile(string filename)
        {
            var image = CreateImageSource(filename);
            return new ImageFile(image.imageSource, image.hasImage);
        }

        private (ImageSource imageSource, bool hasImage) CreateImageSource(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                var fullname = Path.Combine(_fileStrage.ImagesDirectory.FullName, filename);
                if (File.Exists(fullname))
                {
                    return (ImageSource.FromFile(fullname), true);
                }
            }
            return (ResourceImages.NoImage, false);
        }
    }
}
