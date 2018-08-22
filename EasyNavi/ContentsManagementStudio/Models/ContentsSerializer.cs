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
    static class ContentsSerializer
    {
        public static void Serialize(Stream stream, IEnumerable<ContentSummaryViewModel> summaries)
        {
            FillContentId(summaries);
            FillImageName(summaries);

            using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
            {
                WriteSummaries(zip, summaries);
                WriteTopImages(zip, summaries);
                WriteDetailImages(zip, summaries);
            }
        }

        private static void FillContentId(IEnumerable<ContentSummaryViewModel> summaries)
        {
            var ids = summaries.Where(summary => summary.ContentId != null).Select(summary => summary.ContentId.GetValueOrDefault()).ToArray();
            var maxContentId = summaries.Max(summary => summary.ContentId) ?? 0;
            var newContents = summaries.Where(summary => summary.ContentId == null).ToArray();
            var newIds = Enumerable.Range(1, maxContentId + newContents.Length).Except(ids);
            var newContensAndIds = newContents.Zip(newIds, (content, id) => new { Content = content, Id = id });
            foreach (var newContentAndId in newContensAndIds)
                newContentAndId.Content.ContentId = newContentAndId.Content.Detail.ContentId = newContentAndId.Id;
        }

        private static void FillImageName(IEnumerable<ContentSummaryViewModel> summaries)
        {
            foreach (var summary in summaries)
            {
                summary.TopFilename = summary.TopImage == null ? null : FileNames.GetTopImage(summary.ContentId);
                var detailImages = new(bool hasImage, Action<string> setter)[] {
                    (summary.Detail.TopImage!=null, filename=>summary.Detail.TopFilename=filename),
                    (summary.Detail.DetailImage1!=null, filename=>summary.Detail.DetailFilename1=filename),
                    (summary.Detail.DetailImage2!=null, filename=>summary.Detail.DetailFilename2=filename),
                    (summary.Detail.DetailImage3!=null, filename=>summary.Detail.DetailFilename3=filename),
                    (summary.Detail.DetailImage4!=null, filename=>summary.Detail.DetailFilename4=filename),
                    (summary.Detail.DetailImage5!=null, filename=>summary.Detail.DetailFilename5=filename),
                }.Select((detail, index) => (detail.hasImage, detail.setter, index));

                foreach (var (hasImage, setter, index) in detailImages)
                    setter.Invoke(hasImage ? FileNames.GetDetailImage(summary.ContentId, index) : null);
            }
        }

        private static void WriteSummaries(ZipArchive zip, IEnumerable<ContentSummaryViewModel> summaries)
        {
            using (var entry = zip.CreateEntry(FileNames.Summary).Open())
            using (var writer = new StreamWriter(entry))
                writer.Write(JsonConvert.SerializeObject(new JsonContentSummaries()
                {
                    ContentSummaries = summaries.Select(summary => PropertyCopier.CopyTo(summary, new JsonContentSummary())).ToList()
                }));

            foreach (var detail in summaries.Select(summary => summary.Detail))
                using (var entry = zip.CreateEntry(FileNames.GetDetail(detail.ContentId)).Open())
                using (var writer = new StreamWriter(entry))
                    writer.Write(JsonConvert.SerializeObject(PropertyCopier.CopyTo(detail, new JsonContentDetail())));
        }

        private static void WriteTopImages(ZipArchive zip, IEnumerable<ContentSummaryViewModel> summaries)
        {
            var images = summaries.Where(summary => summary.TopImage != null)
                .Select(summary => (summary.TopFilename, summary.TopImage)).ToArray();
            WriteImageFiles(zip, FileNames.Images, images);
        }

        private static void WriteDetailImages(ZipArchive zip, IEnumerable<ContentSummaryViewModel> summaries)
        {
            foreach (var summary in summaries)
            {
                var zipFileName = FileNames.GetDetailImages(summary.ContentId);

                var images = new(string filename, BitmapImage image)[] {
                    (summary.Detail?.TopFilename, summary.Detail?.TopImage),
                    (summary.Detail?.DetailFilename1, summary.Detail?.DetailImage1),
                    (summary.Detail?.DetailFilename2, summary.Detail?.DetailImage2),
                    (summary.Detail?.DetailFilename3, summary.Detail?.DetailImage3),
                    (summary.Detail?.DetailFilename4, summary.Detail?.DetailImage4),
                    (summary.Detail?.DetailFilename5, summary.Detail?.DetailImage5),
                }.Where(image => image.image != null).ToArray();

                WriteImageFiles(zip, zipFileName, images);
            }
        }

        private static void WriteImageFiles(ZipArchive zip, string zipFileName, IEnumerable<(string Filename, BitmapImage Image)> images)
        {
            using (var zipFile = zip.CreateEntry(zipFileName).Open())
            using (var entry = new ZipArchive(zipFile, ZipArchiveMode.Create))
                if (images.Count() != 0)
                {
                    foreach (var image in images)
                        WriteImageFile(entry, image.Filename, image.Image);
                }
                else
                {
                    WriteDummyFile(entry);
                }
        }

        private static void WriteImageFile(ZipArchive zip, string filename, BitmapImage image)
        {
            using (var entry = zip.CreateEntry(filename).Open())
            using (var memoryStream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(memoryStream);
                memoryStream.Position = 0;
                memoryStream.CopyTo(entry);
            }
        }

        private static void WriteDummyFile(ZipArchive zip)
        {
            using (var entry = zip.CreateEntry(FileNames.Dummy).Open())
            using (var writer = new StreamWriter(entry))
                writer.Write(FileNames.Dummy);
        }
    }
}
