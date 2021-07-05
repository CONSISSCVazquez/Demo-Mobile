using Flexbaze.Util;
using Flexbaze.ViewModels;
using Flexbaze.Views;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace Flexbaze
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private LocalizationResourceManager lrmViewModel;
        public MainPage()
        {
            InitializeComponent();
            if (Settings.IsLoggedIn == "false" || Settings.IsLoggedIn == "")
            {
                Navigation.PopToRootAsync();
                App.Current.MainPage = new NavigationPage(new Login());
            }
            else
            {
                Navigation.PopToRootAsync();
                App.Current.MainPage = new NavigationPage(new Dashboard()) { BarBackgroundColor = Color.FromHex("#101630") };
            }
            lrmViewModel = new LocalizationResourceManager();
        }

        public void ReloadApp(string language)
        {
            Settings.Language = language;
            lrmViewModel.SetCulture(CultureInfo.CreateSpecificCulture(language));
            App.Current.MainPage = new MainPage();
        }
    }
}