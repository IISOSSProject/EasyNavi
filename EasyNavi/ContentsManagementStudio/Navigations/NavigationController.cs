using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentsManagementStudio.Navigations
{
    class NavigationController
    {
        public static NavigationController Instance { get; } = new NavigationController();

        private NavigationController() {; }

        public INavigation Navigation { get; set; }

        public void GoNext() => Navigation?.GoNext();
        public void GoBack() => Navigation?.GoBack();
    }
}
