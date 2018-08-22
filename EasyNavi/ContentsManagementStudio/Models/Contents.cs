using ContentsManagementStudio.ViewModels.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentsManagementStudio.Models
{
    class Contents
    {
        public static Contents Instance { get; } = new Contents();
        private Contents() {; }

        public ObservableCollection<ContentSummaryViewModel> Items { get; } = new ObservableCollection<ContentSummaryViewModel>();
    }
}
