using ContentsManagementStudio.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContentsManagementStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INavigation
    {
        public MainWindow()
        {
            InitializeComponent();

            frame.Navigate(new Views.ContentsPage());
            NavigationController.Instance.Navigation = this;
        }

        public void GoBack()
        {
            frame.GoBack();
        }

        public void GoNext()
        {
            frame.Navigate(new Views.ContentDetailPage());
        }

        private void OpenLicenses_Click(object sender, RoutedEventArgs e)
        {
            new Views.LicensesWindow().ShowDialog();
        }
    }
}
