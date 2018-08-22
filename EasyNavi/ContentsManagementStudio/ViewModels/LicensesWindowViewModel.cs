using ContentsManagementStudio.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentsManagementStudio.ViewModels
{
    class LicensesWindowViewModel : BindableBase
    {
        private string _licenses;
        public string Licenses { get => _licenses; set => SetProperty(ref _licenses, value); }

        public LicensesWindowViewModel()
        {
            Licenses = "Newtonsoft.Json" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            var files = typeof(App).Assembly.GetManifestResourceNames();
            using (var stream = typeof(App).Assembly.GetManifestResourceStream("ContentsManagementStudio.Resources.Licenses.NewtonsoftJson.txt"))
            using (var reader = new StreamReader(stream))
                Licenses += reader.ReadToEnd();

        }
    }
}
