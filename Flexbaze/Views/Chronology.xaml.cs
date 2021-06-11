using Flexbaze.Models;
using Flexbaze.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chronology : ContentPage
    {
        private ChronologyViewModel chronologyViewModel;
        public Chronology()
        {
            InitializeComponent();
            Ini();
        }

        private void Ini()
        {
            chronologyViewModel = new ChronologyViewModel();
            BindingContext = chronologyViewModel;
        }

        private void BtnCalendar_Clicked(object sender, EventArgs e)
        {
            DatePicker picker = selectedDate;
            picker.Focus();
        }

        private void BtnPlant_Clicked(object sender, EventArgs e)
        {
            BorderlessPicker plant = ddlPlant;
            plant.Focus();
        }

        private void BtnCell_Clicked(object sender, EventArgs e)
        {
            BorderlessPicker cell = ddlCell;
            cell.Focus();
        }

        private void OnPlantSelected(object sender, EventArgs e)
        {
            Picker pick = (Picker)sender;
            if (pick.SelectedIndex == 0)
            {
                pick.Unfocus();
                pick.ItemsSource[0] = "G";
                ddlPlant.ItemsSource = pick.ItemsSource;
            }
        }
       
        private void Ticket_Clicked(object sender, EventArgs e)
        {
            
        }

        private void OpenItemTapped_Click(object sender, ItemTappedEventArgs e)
        {
            ChronologyViewModel vm = (ChronologyViewModel)this.BindingContext;
            Ticket t = (Ticket)e.Item;
            ObservableCollection<Ticket> tL = new ObservableCollection<Ticket>();
            foreach (Ticket tck in vm.OpenTicketList)
            {
                tL.Add(tck);
            }

            foreach (Ticket tck in tL)
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
            foreach (Ticket tic in tL)
            {
                vm.OpenTicketList.Add(tic);
            }
        }

        private void InProcessItemTapped_Click(object sender, ItemTappedEventArgs e)
        {
            ChronologyViewModel vm = (ChronologyViewModel)this.BindingContext;
            Ticket t = (Ticket)e.Item;
            ObservableCollection<Ticket> tL = new ObservableCollection<Ticket>();
            foreach (Ticket tck in vm.InProcessTicketList)
            {
                tL.Add(tck);
            }

            foreach (Ticket tck in tL)
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
            foreach (Ticket tic in tL)
            {
                vm.InProcessTicketList.Add(tic);
            }
        }

        private void ClosedItemTapped_Click(object sender, ItemTappedEventArgs e)
        {
            ChronologyViewModel vm = (ChronologyViewModel)this.BindingContext;
            Ticket t = (Ticket)e.Item;
            ObservableCollection<Ticket> tL = new ObservableCollection<Ticket>();
            foreach (Ticket tck in vm.ClosedTicketList)
            {
                tL.Add(tck);
            }

            foreach (Ticket tck in tL)
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
            foreach (Ticket tic in tL)
            {
                vm.ClosedTicketList.Add(tic);
            }
        }
    }
}