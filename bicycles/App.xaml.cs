using System;

using Xamarin.Forms;

namespace bicycles
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }

        public static INavigation Navigation { get; private set; }
        public static Page GetMainPage()
        {
            if (Device.RuntimePlatform == Device.iOS) {
                var rootPage = new MainPage();
                Navigation = rootPage.Navigation;
                return rootPage;
            } else {
                var rootPage = new NavigationPage(new MainPage());
                Navigation = rootPage.Navigation;
                return rootPage;
            }
        }
    }
}
