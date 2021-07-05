using Flexbaze.Models;
using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatView : ContentPage
    {
        public ChatView()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel(Navigation);
        }

        private async void ChatDetail(object sender, SelectionChangedEventArgs e)
        {
            Chat itemSelected = (Chat)e.CurrentSelection[0];
            await Navigation.PushAsync(new ChatViewDetail(itemSelected.Id));
        }
    }
}