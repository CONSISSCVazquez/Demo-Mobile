using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayAlertPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        TaskCompletionSource<bool> _tcs = null;

        public DisplayAlertPage(String title, String message, String op1, String op2)
        {
            InitializeComponent();
            TitleAlert.Text = title;
            Message.Text = message;
            opOne.Text = op1;
            opTwo.Text = op2;

            var semiTransparentColor = new Color(16, 22, 48, 0.52);
            stack.BackgroundColor = semiTransparentColor;

            opOne.Clicked += async (sender, e) =>
            {
                await Navigation.PopAllPopupAsync();
                _tcs?.SetResult(false);
            };
            opTwo.Clicked += async (sender, e) =>
            {
                await Navigation.PopAllPopupAsync();
                _tcs?.SetResult(true);
            };
        }

        public async Task<bool> Show()
        {
            _tcs = new TaskCompletionSource<bool>();
            await Navigation.PushPopupAsync(this);

            return await _tcs.Task;
        }
    }
}