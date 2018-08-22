using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EasyNavi.Core.Resources.Images
{
    public static class ResourceImages
    {
        private static string _basePath;
        public static string BasePath => _basePath ?? (_basePath = typeof(ResourceImages).Namespace + ".");
        public static ImageSource FromName([CallerMemberName]string fileName = null) => ImageSource.FromResource($"{BasePath}{fileName}");
        public static ImageSource PngFromName([CallerMemberName]string fileName = null) => FromName(Path.ChangeExtension(fileName, "png"));

        public static ImageSource NoImage => PngFromName();
        public static ImageSource MainTitle => PngFromName();
        public static ImageSource Background => PngFromName();
        public static ImageSource Contents => PngFromName();
        public static ImageSource Favorites => PngFromName();
        public static ImageSource Events => PngFromName();
        public static ImageSource Settings => PngFromName();
        public static ImageSource Questionnaires => PngFromName();
        public static ImageSource WebSites => PngFromName();
        public static ImageSource BackButton => PngFromName();
        public static ImageSource SearchButton => PngFromName();
        public static ImageSource FavoriteButton => PngFromName();
        public static ImageSource CategoryGourmet => PngFromName();
        public static ImageSource CategoryLocalGourmet => PngFromName();
        public static ImageSource CategoryPresent => PngFromName();
        public static ImageSource CategorySpecial => PngFromName();
        public static ImageSource CategoryStaySpring => PngFromName();
        public static ImageSource CategoryToiletParking => PngFromName();
        public static ImageSource CategoryTransferLife => PngFromName();
    }
}
