using Com.OneSignal;
using Flexbaze.Models;
using Flexbaze.Util;
using Flexbaze.ViewModels;
using Flexbaze.Resources;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public LoginViewModel _DetalleUser = new LoginViewModel();
        public WebToken _response;
        public Login()
        {
            if (Settings.Language != "y" && Settings.Language != App.Language.Name)
                App.Language = CultureInfo.GetCultureInfo(Settings.Language);
            InitializeComponent();
            App.AppVersion = VersionTracking.CurrentVersion;
            if (Settings.UserName != "")
            {
                UserName.Text = Settings.UserName;
                Password.Text = Settings.Password;
                cbxRemember.IsChecked = true;
            }
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            btnSignIn.IsEnabled = false;
            string username = UserName.Text;
            string password = Password.Text;
            bool remember = cbxRemember.IsChecked;
            GetToken(username, password, remember);
        }
        public async void GetToken(string usr, string pass, bool rem)
        {
            try
            {
                if (await ValidarFormulario())
                {
                    _response = await _DetalleUser.GetToken(usr, pass);

                    if (_response != null)
                    {
                        Settings.IsLoggedIn = "true";
                        OneSignal.Current.SetSubscription(true);
                        Settings.Token = _response.Token;
                        Settings.Email = _response.User.Email;
                        Settings.Node = _response.User.Id;
                        if (rem)
                        {
                            Settings.UserName = usr;
                            Settings.Password = pass;
                        }
                        App.SetExternalUserId();
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Flexbaze", AppResources.LoginFail, AppResources.Accept);
                        btnSignIn.IsEnabled = true;
                    }
                }
                else
                {
                    btnSignIn.IsEnabled = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                btnSignIn.IsEnabled = true;
            }
        }

        private async Task<bool> ValidarFormulario()
        {
            //Valida si el valor en el Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(UserName.Text))
            {
                await DisplayAlert("Flexbaze", AppResources.UsernameRequired, AppResources.Accept);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(Password.Text))
            {
                await DisplayAlert("Flexbaze", AppResources.PasswordRequired, AppResources.Accept);
                return false;
            }
            return true;
        }

        private async void BtnRecover_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPassword());
        }

        private void BtnViewPass_Tapped(object sender, EventArgs e)
        {
            if (Password.IsPassword)
            {
                Password.IsPassword = false;
                ic_pass.Source = "hide_pass.png";
            }
            else
            {
                Password.IsPassword = true;
                ic_pass.Source = "view_pass.png";
            }
        }
    }
}