using Flexbaze.Models;
using Flexbaze.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Flexbaze.ViewModels.ChronologyViewModel;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chronology : ContentPage, INavigationHandler
    {
        private ChronologyViewModel chronologyViewModel;
        public Chronology()
        {
            InitializeComponent();
            Ini();
        }

        private void Ini()
        {
            chronologyViewModel = new ChronologyViewModel(this);
            BindingContext = chronologyViewModel;
        }

        private void BtnCalendar_Clicked(object sender, EventArgs e)
        {
            DatePicker picker = selectedDate;
            picker.Focus();
        }

        private void BtnCell_Clicked(object sender, EventArgs e)
        {
            BorderlessPicker cell = ddlCell;
            cell.Focus();
        }

        private void OnPlantSelected(object sender, EventArgs e)
        {
            Picker pick = (Picker)sender;
            FactoryType fSel = (FactoryType)pick.SelectedItem;
            if (fSel != null)
                Console.Write("Id selected: " + fSel.Id);
        }
       
        private void Ticket_Clicked(object sender, EventArgs e)
        {
            
        }

        private void OpenItemTapped_Click(object sender, ItemTappedEventArgs e)
        {
            ChronologyViewModel vm = (ChronologyViewModel)this.BindingContext;
            TicketComplete t = (TicketComplete)e.Item;
            ObservableCollection<TicketComplete> tL = new ObservableCollection<TicketComplete>();
            foreach (TicketComplete tck in vm.OpenTicketList)
            {
                tL.Add(tck);
            }

            foreach (TicketComplete tck in tL)
            {
                if (tck.Id == t.Id)
                {
                    if (tck.IsSelected)
                    {
                        tck.IsSelected = false;
                        break;
                    }
                    else
                    {
                        tck.IsSelected = true;
                        break;
                    }
                }
            }

            vm.OpenTicketList.Clear();
            foreach (TicketComplete tic in tL)
            {
                vm.OpenTicketList.Add(tic);
            }
        }

        private void InProcessItemTapped_Click(object sender, ItemTappedEventArgs e)
        {
            ChronologyViewModel vm = (ChronologyViewModel)BindingContext;
            TicketComplete t = (TicketComplete)e.Item;
            ObservableCollection<TicketComplete> tL = new ObservableCollection<TicketComplete>();
            foreach (TicketComplete tck in vm.InProcessTicketList)
            {
                tL.Add(tck);
            }

            foreach (TicketComplete tck in tL)
            {
                if (tck.Id == t.Id)
                {
                    if (tck.IsSelected)
                    {
                        tck.IsSelected = false;
                        break;
                    }
                    else
                    {
                        tck.IsSelected = true;
                        break;
                    }
                }
            }

            vm.InProcessTicketList.Clear();
            foreach (TicketComplete tic in tL)
            {
                vm.InProcessTicketList.Add(tic);
            }
        }

        private void ClosedItemTapped_Click(object sender, ItemTappedEventArgs e)
        {
            ChronologyViewModel vm = (ChronologyViewModel)BindingContext;
            TicketComplete t = (TicketComplete)e.Item;
            ObservableCollection<TicketComplete> tL = new ObservableCollection<TicketComplete>();
            foreach (TicketComplete tck in vm.ClosedTicketList)
            {
                tL.Add(tck);
            }

            foreach (TicketComplete tck in tL)
            {
                if (tck.Id == t.Id)
                {
                    if (tck.IsSelected)
                    {
                        tck.IsSelected = false;
                        break;
                    }
                    else
                    {
                        tck.IsSelected = true;
                        break;
                    }
                }
            }

            vm.ClosedTicketList.Clear();
            foreach (TicketComplete tic in tL)
            {
                vm.ClosedTicketList.Add(tic);
            }
        }

        public void AssignTicketAsync(string ticketId, string status)
        {
            Navigation.PushAsync(new SupportDetailAssign(ticketId, status));
        }

        public void ViewDetailsTicketAsync(TicketComplete ticket, string factory)
        {
            Navigation.PushAsync(new SupportDetail(ticket, factory));
        }

        private void MnuDashboard_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Dashboard()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuSupport_Clicked(object sender, EventArgs e)
        {
        }

        private void MnuOEE_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new OEEMachines()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuNotification_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Notifications()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuProfile_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Profile()) { BarBackgroundColor = Color.FromHex("#101630") };
        }
    }
}