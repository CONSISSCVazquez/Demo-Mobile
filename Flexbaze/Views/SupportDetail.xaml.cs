using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportDetail : ContentPage
    {
        private SupportDetailViewModel detailViewModel;
        public SupportDetail(string ticketId, string status)
        {
            InitializeComponent();
            Ini(ticketId, status);
        }

        private void Ini(string ticketId, string status)
        {
            detailViewModel = new SupportDetailViewModel(ticketId, status);
            BindingContext = detailViewModel;
        }
    }
}