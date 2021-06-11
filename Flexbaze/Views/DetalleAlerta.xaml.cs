using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalleAlerta : ContentPage
	{
        private Models.Alerts alerta;
        private DetalleAlertaViewModel _detalleAlerta;
        public DetalleAlerta( string NotifyNode)
        {
            InitializeComponent();
            this.alerta= new Models.Alerts();// hay que obtener la info de la notificacion por medio de su nodo
            Ini(NotifyNode);
        }

		public DetalleAlerta (Models.Alerts alerta)
		{
			InitializeComponent();
            this.alerta = alerta;
            Ini();
		}

        private void Ini(string NotifyNode)
        {
            _detalleAlerta = new DetalleAlertaViewModel(PullToRefresh,NotifyNode, NewMessage, ListViewMessages);
            BindingContext = _detalleAlerta;
        }

        private void Ini()
        {
            _detalleAlerta = new DetalleAlertaViewModel(PullToRefresh,alerta, NewMessage, ListViewMessages);
            BindingContext = _detalleAlerta;
        }
        protected override void OnDisappearing()
        {
            _detalleAlerta.CanUpdate = false;
        }
	}
}