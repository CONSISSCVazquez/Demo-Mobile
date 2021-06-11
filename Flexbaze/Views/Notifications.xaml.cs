using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flexbaze.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notifications : ContentPage
    {
        private AlertsViewModel alertsViewModel;
        public Notifications()
        {
            InitializeComponent();
            Ini();
        }

        private void Ini()
        {
            alertsViewModel = new AlertsViewModel();
            BindingContext = alertsViewModel;
        }
        private void BtnNews_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnAll_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}