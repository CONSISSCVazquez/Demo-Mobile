using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatViewDetail : ContentPage
    {
        public ChatViewDetail(string id)
        {
            InitializeComponent();
            BindingContext = new ChatViewDetailModel(id);
        }
    }
}