using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Flexbaze.Models;
using Flexbaze.ViewModels;
using Flexbaze.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ForgotPasswordViewModel _forgotPwdVM = new ForgotPasswordViewModel();
        public SendPasswordResetEmail _response;
        public ForgotPassword()
        {
            InitializeComponent();
            var semiTransparentColor = new Color(16, 22, 48, 0.52);
            stack.BackgroundColor = semiTransparentColor;

            opOne.Clicked += (sender, e) =>
            {
                IsVisible = false;
            };
            opTwo.Clicked += async (sender, e) =>
            {
                if (await ValidarFormulario())
                {
                    await DisplayAlert("Flexbaze", AppResources.EmailSent, AppResources.Accept);
                    IsVisible = false;
                    //_response = await _forgotPwdVM.SendEmail(Email.Text);
                    //if (_response.Success)
                    //{
                    //    await DisplayAlert("Flexbaze", "Email was sent.", "OK");
                    //    IsVisible = false;
                    //}
                }
            };
        }

        private async Task<bool> ValidarFormulario()
        {
            //Valida si el valor en el Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(Email.Text))
            {
                await DisplayAlert("Flexbaze", AppResources.EmailRequired, AppResources.Accept);
                return false;
            }
            else if (!Regex.IsMatch(Email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    await DisplayAlert("Flexbaze", AppResources.EmailFail, AppResources.Accept);
                    return false;
                }
            else
                return true;
        }
    }
}