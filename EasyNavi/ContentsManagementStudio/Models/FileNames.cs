using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentsManagementStudio.Models
{
    static class FileNames
    {
        public static string Summary { get; } = "summaries.json";
        public static string Detail { get; } = "detail_{0}.json";
        public static string GetDetail(int? id) => string.Format(Detail, id);
        public static string Images { get; } = "images.zip";
        public static string DetailImages { get; } = "images_{0}.zip";
        public static string GetDetailImages(int? id) => string.Format(DetailImages, id);
        public static string Dummy { get; } = "dummy";
        public static string TopImage { get; } = "{0}_0.png";
        public static string GetTopImage(int? id)=>string.Format(TopImage, id);
        public static string DetailImage { get; } = "{0}_{1}.png";
        public static string GetDetailImage(int? id, int index) => string.Format(DetailImage, id, index);
    }
}
