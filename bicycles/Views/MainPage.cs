using System;
using bicycles.Views;
using Xamarin.Forms;

namespace bicycles
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page bicyclesPage, clientsPage, reservationsPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "Aplikacja"
                    };
                    bicyclesPage = new NavigationPage(new BicyclesPage())
                    {
                        Title = "Rowery"
                    };
                    clientsPage = new NavigationPage(new ClientsPage())
                    {
                        Title = "Klienci"
                    };
                    reservationsPage = new NavigationPage(new ReservationsPage())
                    {
                        Title = "Rezerwacje"
                    };
                    bicyclesPage.Icon = "tab_feed.png";
                    clientsPage.Icon = "tab_feed.png";
                    reservationsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    aboutPage = new AboutPage()
                    {
                        Title = "Aplikacja"
                    };
                    bicyclesPage = new BicyclesPage()
                    {
                        Title = "Rowery"
                    };
                    clientsPage = new ClientsPage()
                    {
                        Title = "Klienci"
                    };
                    reservationsPage = new ReservationsPage()
                    {
                        Title = "Rezerwacje"
                    };
                    break;
            }
            Children.Add(aboutPage);
            Children.Add(bicyclesPage);
            Children.Add(clientsPage);
            Children.Add(reservationsPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
