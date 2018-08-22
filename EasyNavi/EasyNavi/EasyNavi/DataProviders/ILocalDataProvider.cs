using EasyNavi.Core.DataObjects.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyNavi.Core.DataProviders
{
    interface ILocalDataProvider
    {
        IEnumerable<(ImageSource Image, int Id, string Name)> ContentCategory();

        IEnumerable<(ImageSource Image, int? Id, string Name, string Detail)> Contents(string categoryId, IEnumerable<string> texts);

        ContentDetailEntity Content(int? contentId);

        void UnzipImages(byte[] bytes);

        IEnumerable<ContentSummaryEntity> ContentSummaries(SQLite.SQLiteConnection db);

        IEnumerable<ContentDetailEntity> ContentDetails(SQLite.SQLiteConnection db);

        int InsertOrReplace(SQLiteConnection db, ContentSummaryEntity entiry);
        int InsertOrReplace(SQLiteConnection db, ContentDetailEntity entiry);
        int InsertOrReplace(SQLiteConnection db, DataVersionsEntity entiry);
    }
}
