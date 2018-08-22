using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyNavi.Plugin.License.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LicensesPage : ContentPage
    {
        public LicensesPage()
        {
            InitializeComponent();
        }

        private void List_ItemSelected(object sender, EventArgs e) => listView.SelectedItem = null;

        private void Back_Tapped(object sender, EventArgs e) => Navigation.PopModalAsync();
    }
}