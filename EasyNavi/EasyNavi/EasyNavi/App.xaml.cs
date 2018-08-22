using EasyNavi.Core.SetUps;
using EasyNavi.PluginInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using Xamarin.Forms;

namespace EasyNavi
{
    public partial class App : Application
    {
        public static IUnityContainer DIContainer { get; } = new UnityContainer();

        public static IList<IEasyNaviPlugin> Plugins { get; } = new List<IEasyNaviPlugin>();

        public App()
        {
            InitializeComponent();

            SetUp.Set();

            MainPage = new NavigationPage(new EasyNavi.Core.Views.MainMenuView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
