using Flexbaze.Util;
using Flexbaze.ViewModels;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        private LocalizationResourceManager lrmViewModel;
        public Profile()
        {
            InitializeComponent();
            lrmViewModel = new LocalizationResourceManager();
            lblVersion.Text += " " + App.AppVersion;
        }

        private void Reload(string language)
        {
            Settings.Language = language;
            lrmViewModel.SetCulture(CultureInfo.CreateSpecificCulture(language));
            App.Current.MainPage = new NavigationPage(new Profile()) { BarBackgroundColor = Color.FromHex("#101630") };
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
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Notifications()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuUser_Clicked(object sender, EventArgs e)
        {
        }

        private void BtnLanguage_Clicked(object sender, EventArgs e)
        {
            if (slLanguages.IsVisible)
                slLanguages.IsVisible = false;
            else
                slLanguages.IsVisible = true;
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Login());
        }

        private void BtnSpanish_Clicked(object sender, EventArgs e)
        {
            Reload("ES");
        }

        private void BtnEnglish_Clicked(object sender, EventArgs e)
        {
            Reload("EN");
        }
    }
}