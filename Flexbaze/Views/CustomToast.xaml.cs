using Rg.Plugins.Popup.Extensions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomToast : Rg.Plugins.Popup.Pages.PopupPage
    {
        TaskCompletionSource<bool> _tcs = null;

        public CustomToast(Color color, string MessageToast, string IconToast)
        {
            InitializeComponent();
            StackL.BackgroundColor = color;
            Message.Text = MessageToast;
            IconT.Source = IconToast;
        }

        public async Task<bool> Show()
        {
            _tcs = new TaskCompletionSource<bool>();
            await Navigation.PushPopupAsync(this);

            return await _tcs.Task;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAllPopupAsync();
        }
    }
}