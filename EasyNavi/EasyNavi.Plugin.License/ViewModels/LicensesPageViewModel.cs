using EasyNavi.Plugin.License.Entities;
using EasyNavi.PluginInterfaces.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EasyNavi.Plugin.License.ViewModels
{
    class LicensesPageViewModel
    {
        public ObservableCollection<LicenseEntity> Items { get; } = new ObservableCollection<LicenseEntity>();

        public LicensesPageViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            var licenses = new List<LicenseEntity>();
            using(var db = LicensePlugin.Instance.DataBaseConnectionFactory.Invoke())
            {
                var entities = db.Table<LicenseEntity>().OrderBy(entity => entity.Id);
                licenses.AddRange(entities);
            }
            foreach(var license in licenses)
            {
                Items.Add(license);
            }
        }
    }
}
