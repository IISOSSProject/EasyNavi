using ContentsManagementStudio.Commons;
using ContentsManagementStudio.ViewModels.DataModels;
using EasyNavi.Models.APIJsonModels.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ContentsManagementStudio.Models
{
    static class ContentsDeserializer
    {
        public static IEnumerable<ContentSummaryViewModel> Deserialize(Stream stream)
        {
            using (var zip = new ZipArchive(stream))
            {
                var summaries = Summaryies(zip);
                summaries = TopImages(zip, summaries);
                summaries = DetailImages(zip, summaries);

                return summaries;
            }
        }

        private static IEnumerable<ContentSummaryViewModel> Summaryies(ZipArchive zip)
        {
            List<ContentSummaryViewModel> summaries = new List<ContentSummaryViewModel>();
            using (var entry = zip.GetEntry(FileNames.Summary).Open())
            using (var reader = new StreamReader(entry))
                summaries.AddRange(JsonConvert.DeserializeObject<JsonContentSummaries>(reader.ReadToEnd()).ContentSummaries.Select(summary => PropertyCopier.CopyTo(summary, new ContentSummaryViewModel())));

            foreach (var summary in summaries)
            {
                using (var entry = zip.GetEntry(FileNames.GetDetail(summary.ContentId)).Open())
                using (var reader = new StreamReader(entry))
                    summary.Detail = PropertyCopier.CopyTo(JsonConvert.DeserializeObject<JsonContentDetail>(reader.ReadToEnd()), new ContentDetaiViewModel());
            }

            return summaries;
        }

        private static IEnumerable<ContentSummaryViewModel> TopImages(ZipArchive zip, IEnumerable<ContentSummaryViewModel> summaries)
        {
            var entry = zip.GetEntry(FileNames.Images);
            if (entry == null) return summaries;

            using (var entryStream = entry.Open())
            using (var imagesZip = new ZipArchive(entryStream))
                foreach (var image in imagesZip.Entries)
                {
                    if (!int.TryParse(image.FullName.Split('_').First(), out var id)) continue;

                    var summary = summaries.Where(s => s.ContentId == id).FirstOrDefault();
                    if (summary == null) continue;

                    summary.TopImage = CreateBitmapImage(image);
                }

            return summaries;
        }

        private static IEnumerable<ContentSummaryViewModel> DetailImages(ZipArchive zip, IEnumerable<ContentSummaryViewModel> summaries)
        {
            foreach (var summary in summaries)
            {
                if (summary.Detail == null) continue;

                var entry = zip.GetEntry(FileNames.GetDetailImages(summary.ContentId));
                if (entry == null) continue;

                var setters = new Action<BitmapImage>[] {
                    image => summary.Detail.DetailImage1 = image,
                    image => summary.Detail.DetailImage2 = image,
                    image => summary.Detail.DetailImage3 = image,
                    image => summary.Detail.DetailImage4 = image,
                    image => summary.Detail.DetailImage5 = image,
                };

                using (var entryStream = entry.Open())
                using (var imagesZip = new ZipArchive(entryStream))
                    foreach (var imageAndSetter in imagesZip.Entries.OrderBy(image => image.FullName).Skip(1).Zip(setters, (image, setter) => new { Image = image, Setter = setter }))
                        imageAndSetter.Setter.Invoke(CreateBitmapImage(imageAndSetter.Image));
            }

            return summaries;
        }

        private static BitmapImage CreateBitmapImage(ZipArchiveEntry image)
        {
            if (FileNames.Dummy == image.FullName) return null;
            using (var imageStream = image.Open())
            {
                var bs = new BinaryReader(imageStream);
                int b;
                var q = new Queue<byte>();
                while ((b = imageStream.ReadByte()) != -1) q.Enqueue((byte)b);
                using (var m = new MemoryStream(q.ToArray()))
                {
                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = m;
                    try
                    {
                        bi.EndInit();
                    }catch(NotSupportedException ex)
                    {
                        Console.WriteLine($"{ex.Message} FileName:{image.FullName}");
                        return null;
                    }
                    return bi;
                }
            }
        }
    }
}
