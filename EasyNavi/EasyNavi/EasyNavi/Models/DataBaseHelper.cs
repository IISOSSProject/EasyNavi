using EasyNavi.Core.DataObjects.Entities;
using EasyNavi.Core.Resources.Images;
using EasyNavi.Core.Resources.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.Models
{
    public static class DataBaseHelper
    {
        private static string DataBasePath { get; } = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SQLiteDataBase.db");

        public static void CreateDataBase()
        {
            using (var db = new SQLite.SQLiteConnection(DataBasePath))
            {
                db.CreateTable<DataVersionsEntity>();
                if (!db.Table<DataVersionsEntity>().Any())
                    db.Insert(new DataVersionsEntity());
                db.CreateTable<CategoryLargeEntity>();
                if (!db.Table<CategoryLargeEntity>().Any())
                {
                    db.Insert(new CategoryLargeEntity() { Id = 1, ContentCategoryLargeName = ResourceTexts.CategorySpecial, IconFileName = nameof(ResourceImages.CategorySpecial) });
                    db.Insert(new CategoryLargeEntity() { Id = 4, ContentCategoryLargeName = ResourceTexts.CategoryTransferLife, IconFileName = nameof(ResourceImages.CategoryTransferLife) });
                    db.Insert(new CategoryLargeEntity() { Id = 5, ContentCategoryLargeName = ResourceTexts.CategoryStaySpring, IconFileName = nameof(ResourceImages.CategoryStaySpring) });
                    db.Insert(new CategoryLargeEntity() { Id = 2, ContentCategoryLargeName = ResourceTexts.CategoryGourmet, IconFileName = nameof(ResourceImages.CategoryGourmet) });
                    db.Insert(new CategoryLargeEntity() { Id = 3, ContentCategoryLargeName = ResourceTexts.CategoryLocalGourmet, IconFileName = nameof(ResourceImages.CategoryLocalGourmet) });
                    db.Insert(new CategoryLargeEntity() { Id = 6, ContentCategoryLargeName = ResourceTexts.CategoryToiletParking, IconFileName = nameof(ResourceImages.CategoryToiletParking) });
                    db.Insert(new CategoryLargeEntity() { Id = 7, ContentCategoryLargeName = ResourceTexts.CategoryPresent, IconFileName = nameof(ResourceImages.CategoryPresent) });
                }
                db.CreateTable<ContentSummaryEntity>();
                db.CreateTable<ContentDetailEntity>();

                // Plugins
                foreach (var plugin in App.Plugins)
                    plugin.CreateDataBase(db);
            }
        }

        public static SQLite.SQLiteConnection CreateConnection() => new SQLite.SQLiteConnection(DataBasePath);

        public static IEnumerable<T> Select<T>(Func<SQLite.TableQuery<T>, IEnumerable<T>> func) where T : new()
        {
            using (var db = new SQLite.SQLiteConnection(DataBasePath))
            {
                return func(db.Table<T>()).ToArray();
            }
        }
    }
}
