using System;
using System.Globalization;
using Com.OneSignal;
using Flexbaze.Models;
using Flexbaze.Util;
using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : ContentPage
	{
        private LocalizationResourceManager lrmViewModel;
        private Flexbaze_Colors Evco_Colors = new Flexbaze_Colors();
        public string Version { get; set; }
        public string VersionColor { get; set; }
		public Master ()
		{
			InitializeComponent ();
            Version = App.AppVersion;
            VersionColor = Evco_Colors._grisVersion;
            this.WidthRequest = this.Width * 0.7;
            lrmViewModel = new LocalizationResourceManager();
            BindingContext = lrmViewModel;
            LblHello.Text += Settings.UserName;
        }

        private async void BtnLogout_Clicked(object sender, EventArgs e)
		{
			Settings.IsLoggedIn = "false";
            OneSignal.Current.SetSubscription(false);
			App.MasterDP.IsPresented = false;
			await App.MasterDP.Detail.Navigation.PopToRootAsync();
			await App.MasterDP.Detail.Navigation.PushAsync(new Views.Login());
		}

        private async void BtnNotifications_Clicked(object sender, EventArgs e)
        {
            App.MasterDP.IsPresented = false;
            await App.MasterDP.Detail.Navigation.PushAsync(new Notifications());
        }

        private void BtnEvent_Clicked(object sender, EventArgs e)
        {
            StackLayout sl = SupportExpand;
            sl.IsVisible = sl.IsVisible ? false : true;
        }

        private async void BtnInicio_Clicked(object sender, EventArgs e)
        {
            App.MasterDP.IsPresented = false;
            await App.MasterDP.Detail.Navigation.PopToRootAsync();
        }

        public async void NotificationOpened(Models.Alerts alerta)
        {
            App.MasterDP.IsPresented = false;
            await App.MasterDP.Detail.Navigation.PushAsync(new DetalleAlerta(alerta));
        }

        private async void BtnChat_Clicked(object sender, EventArgs e)
        {
            App.MasterDP.IsPresented = false;
            await App.MasterDP.Detail.Navigation.PushAsync(new ChatView());
        }

        private async void BtnSupport_Clicked(object sender, EventArgs e)
        {
            App.MasterDP.IsPresented = false;
            await App.MasterDP.Detail.Navigation.PushAsync(new Chronology());
        }

        private void BtnLanguage_Clicked(object sender, EventArgs e)
        {
            StackLayout sl = LanguageExpand;
            sl.IsVisible = sl.IsVisible ? false : true;
        }

        private async void BtnEnglish_Clicked(object sender, EventArgs e)
        {
            Settings.Language = "EN";
            lrmViewModel.SetCulture(CultureInfo.CreateSpecificCulture("EN"));
            App.MasterDP.IsPresented = false;
            await App.MasterDP.Detail.Navigation.PopToRootAsync();
            await App.MasterDP.Detail.Navigation.PushAsync(new Login());
        }

        private async void BtnSpanish_Clicked(object sender, EventArgs e)
        {
            Settings.Language = "ES";
            lrmViewModel.SetCulture(CultureInfo.CreateSpecificCulture("ES"));
            App.MasterDP.IsPresented = false;
            await App.MasterDP.Detail.Navigation.PopToRootAsync();
            await App.MasterDP.Detail.Navigation.PushAsync(new Login());
        }
    }
}