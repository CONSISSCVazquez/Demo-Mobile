using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportDetailAssign : ContentPage
    {
        private SupportDetailAssignViewModel supportDetailAssignViewModel;
        public SupportDetailAssign(string ticketId, string status)
        {
            InitializeComponent();
            supportDetailAssignViewModel = new SupportDetailAssignViewModel(ticketId, status, Navigation);
            BindingContext = supportDetailAssignViewModel;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            supportDetailAssignViewModel.searchUser(entry.Text);
        }
    }
}