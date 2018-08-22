using ContentsManagementStudio.Commons;
using ContentsManagementStudio.Models;
using ContentsManagementStudio.Navigations;
using ContentsManagementStudio.Navigations.Parameters;
using ContentsManagementStudio.ViewModels.DataModels;
using EasyNavi.Models.APIJsonModels.JsonModels;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContentsManagementStudio.ViewModels
{
    class ContentsPageViewModel : BindableBase
    {
        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SelectedCommand { get; }

        public ObservableCollection<ContentSummaryViewModel> Items { get; } = Contents.Instance.Items;

        public ContentsPageViewModel()
        {
            OpenCommand = new Command(OnOpen);
            SaveCommand = new Command(OnSave);
            SelectedCommand = new Command(OnSelect);
        }

        void OnOpen(object parameter)
        {
            var dialog = new OpenFileDialog { Multiselect = false };
            if (!(true == dialog.ShowDialog())) return;

            while (Items.Any()) Items.RemoveAt(0);

            using (var stream = dialog.OpenFile())
                foreach (var summary in ContentsDeserializer.Deserialize(stream))
                    Items.Add(summary);

        }

        void OnSave(object parameter)
        {
            var dialog = new SaveFileDialog();
            if (!(true == dialog.ShowDialog())) return;

            using (var stream = dialog.OpenFile())
                ContentsSerializer.Serialize(stream, Items.ToArray());
        }

        void OnSelect(object parameter)
        {
            SelectedContent.Instance.Content = (ContentSummaryViewModel)parameter;
            NavigationController.Instance.GoNext();
        }
    }
}
