using EasyNavi.Core.DataObjects.Entities;
using EasyNavi.Core.DataProviders.StrageDataProviders;
using EasyNavi.Core.Models;
using EasyNavi.Core.Resources.Images;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyNavi.Core.DataProviders
{
    class LocalDataProvider : ILocalDataProvider
    {
        private IFileStrage _fileStrage;

        public LocalDataProvider(IFileStrage fileStrage)
        {
            _fileStrage = fileStrage;
        }

        public IEnumerable<(ImageSource Image, int Id, string Name)> ContentCategory() =>
            DataBaseHelper.Select<CategoryLargeEntity>(t => t).Select(d => (ResourceImages.PngFromName(d.IconFileName), d.Id, d.ContentCategoryLargeName)).ToArray();

        public IEnumerable<(ImageSource Image, int? Id, string Name, string Detail)> Contents(string categoryId, IEnumerable<string> texts)
        {
            var imageDataProvider = new ContentImageDataProvider(_fileStrage);
            return DataBaseHelper.Select<ContentSummaryEntity>(t =>
            {
                foreach (var text in texts?.Where(text => !string.IsNullOrEmpty(text)))
                    t = t.Where(r => r.ContentName.Contains(text) || r.ContentDetail.Contains(text));
                if (!string.IsNullOrEmpty(categoryId)) t = t.Where(r => r.ContentCategoryLargeId == categoryId);
                return t;
            })
            .Select(r => (imageDataProvider.ImageFile(r.TopFilename).ImageSource, r.ContentId, r.ContentName, r.ContentDetail))
            .ToArray();
        }

        public ContentDetailEntity Content(int? contentId) => DataBaseHelper.Select<ContentDetailEntity>(t => t.Where(r => r.ContentId == contentId)).FirstOrDefault();

        public void UnzipImages(byte[] bytes) => _fileStrage.UnzipImages(bytes);

        public IEnumerable<ContentSummaryEntity> ContentSummaries(SQLiteConnection db) => db.Table<ContentSummaryEntity>().ToArray();

        public IEnumerable<ContentDetailEntity> ContentDetails(SQLiteConnection db) => db.Table<ContentDetailEntity>().ToArray();

        public int InsertOrReplace(SQLiteConnection db, ContentSummaryEntity entiry) => db.InsertOrReplace(entiry);
        public int InsertOrReplace(SQLiteConnection db, ContentDetailEntity entiry) => db.InsertOrReplace(entiry);
        public int InsertOrReplace(SQLiteConnection db, DataVersionsEntity entiry) => db.InsertOrReplace(entiry);
    }
}
