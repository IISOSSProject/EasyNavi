using EasyNavi.Plugin.License.Entities;
using EasyNavi.PluginInterfaces.Abstracts;
using EasyNavi.PluginInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Plugin.License
{
    public class LicensePlugin : EasyNaviPluginBase
    {
        public static LicensePlugin Instance { get; } = new LicensePlugin();
        private LicensePlugin() {; }

        public override Task Init() => base.Init();

        public override void CreateDataBase(SQLite.SQLiteConnection db)
        {
            db.CreateTable<LicenseEntity>();
        }

        public override async Task<bool> DataUpdate()
        {
            using (var db = DataBaseConnectionFactory.Invoke())
            {
                if (db.Table<LicenseEntity>().Any()) return true;

                (string File, string Product)[] names = new[] {
                    ("NewtonsoftJson", "Newtonsoft.Json"),
                    ("SQLite-net", "sqlite-net-pcl"),
                    ("UnityContainer", "UnityContainer"),
                    ("Xamarin", "Xamarin SDK"),
                };
                (int Id, string File, string Product)[] idAndNames = names.Select((name, index) => (index + 1, name.File, name.Product)).ToArray();

                foreach (var idAndName in idAndNames)
                    db.Insert(await CreateLicenseEntity(idAndName.Id, idAndName.File, idAndName.Product));
            }
            return true;
        }

        private async Task<string> ReadText(string fileName)
        {
            var resourceName = $"EasyNavi.Plugin.License.Resources.Licenses.{fileName}.txt";
            using (var stream = typeof(LicensePlugin).Assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return await reader.ReadToEndAsync();
        }

        private async Task<LicenseEntity> CreateLicenseEntity(int id, string fileName, string productName)
        {
            var text = await ReadText(fileName);
            return new LicenseEntity() { Id = id, Name = productName, Body = text };
        }
    }
}
