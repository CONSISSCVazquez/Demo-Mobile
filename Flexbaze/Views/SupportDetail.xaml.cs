using Flexbaze.Models;
using Flexbaze.Resources;
using Flexbaze.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportDetail : ContentPage
    {
        private SupportDetailViewModel detailViewModel;
        public SupportDetail(TicketComplete ticket, string factory)
        {
            InitializeComponent();
            Ini(ticket, factory);
        }

        private void Ini(TicketComplete ticket, string factory)
        {
            detailViewModel = new SupportDetailViewModel(ticket, factory, Navigation);
            BindingContext = detailViewModel;
        }

        private void OnStatusSelected(object sender, System.EventArgs e)
        {
            Picker pick = (Picker)sender;
            if (pick.SelectedIndex != 0)
            {
                if (pick.SelectedItem.ToString().Equals(AppResources.ClosedLabel))
                {
                    pick.IsEnabled = false;
                }
            }
        }

        private async void ChangeStatus(object sender, EventArgs e)
        {
            var popupAlert = new DisplayAlertPage(AppResources.CloseStatus, AppResources.CloseStatusMessage, AppResources.Cancel, AppResources.Accept);
            var result = await popupAlert.Show();

            //if (result) 
            //Console.WriteLine("Change to action");
        }

        private void Add_Detail_View_Clicked(object sender, EventArgs e)
        {
            AddDetail.IsVisible = false;
            DetailBtns.IsVisible = true;
            EntryDetail.IsVisible = true;
        }

        private void Cancel_Detail_Clicked(object sender, EventArgs e)
        {
            AddDetail.IsVisible = true;
            DetailBtns.IsVisible = false;
            EntryDetail.IsVisible = false;
            Commentary.Text = "";
        }

        private async void AddDetails_Clicked(object sender, EventArgs e)
        {
            await detailViewModel.AddDetail(Commentary.Text);
            AddDetail.IsVisible = true;
            DetailBtns.IsVisible = false;
            EntryDetail.IsVisible = false;
            Commentary.Text = "";
        }
    }
}