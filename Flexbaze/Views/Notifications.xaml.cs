using System;
using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notifications : ContentPage
    {
        private AlertsViewModel alertsViewModel;
        public Notifications()
        {
            InitializeComponent();
            Ini();
        }

        private void Ini()
        {
            alertsViewModel = new AlertsViewModel(Navigation);
            BindingContext = alertsViewModel;
        }
        private void BtnNews_Clicked(object sender, EventArgs e)
        {
        }

        private void BtnAll_Clicked(object sender, EventArgs e)
        {  
        }

        private void MnuDashboard_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Dashboard()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuSupport_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Chronology()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuOEE_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new OEEMachines()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuNotification_Clicked(object sender, EventArgs e)
        {
        }

        private void MnuProfile_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Profile()) { BarBackgroundColor = Color.FromHex("#101630") };
        }
    }
}