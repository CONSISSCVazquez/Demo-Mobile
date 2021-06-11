using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using Flexbaze.ViewModels;
using Flexbaze.Models;
using System.Collections.ObjectModel;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public ActivityIndicatorModel ActivityIndicator = new ActivityIndicatorModel();
        private DashboardViewModel dashboardViewModel;
        private Color Colorbright;
        private Color Colormain;

        public Dashboard()
        {
            InitializeComponent();
            Ini();
            Colorbright = (Color)App.Current.Resources["bright"];
            Colormain = (Color)App.Current.Resources["main"];

            barChart.Chart = new BarChart()
            {
                Entries = dashboardViewModel.EntryList,
                BackgroundColor = SKColor.Parse("#00FFFFFF"),
                LabelTextSize = 20,
                ValueLabelOrientation = Orientation.Horizontal,
                BarAreaAlpha = 0
            };

            scrapChart.Chart = new BarChart()
            {
                Entries = dashboardViewModel.EntryCausesList,
                BackgroundColor = SKColor.Parse("#00FFFFFF"),
                LabelTextSize = 20,
                ValueLabelOrientation = Orientation.Horizontal,
                BarAreaAlpha = 0
            };
        }
        
        private void Ini()
        {
            dashboardViewModel = new DashboardViewModel();
            BindingContext = dashboardViewModel;
        }

        private void BtnIncidents_Clicked(object sender, EventArgs e)
        {
            
        }

        private void BtnToday_Clicked(object sender, EventArgs e)
        {
            Btn_Today.BackgroundColor = Colorbright;
            Btn_Week.BackgroundColor = Colormain;
            Btn_Month.BackgroundColor = Colormain;
            dashboardViewModel.GetData(ddlPlant.SelectedItem.ToString(), "Today");
        }

        private void BtnWeek_Clicked(object sender, EventArgs e)
        {
            Btn_Today.BackgroundColor = Colormain;
            Btn_Week.BackgroundColor = Colorbright;
            Btn_Month.BackgroundColor = Colormain;
            dashboardViewModel.GetData(ddlPlant.SelectedItem.ToString(), "Week");
        }

        private void BtnMonth_Clicked(object sender, EventArgs e)
        {
            Btn_Today.BackgroundColor = Colormain;
            Btn_Week.BackgroundColor = Colormain;
            Btn_Month.BackgroundColor = Colorbright;
            dashboardViewModel.GetData(ddlPlant.SelectedItem.ToString(), "Month");
        }

        private void BtnOEE_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnPlant_Clicked(object sender, EventArgs e)
        {
            string btnSelected = "Today";
            if (Btn_Week.BackgroundColor == Colorbright)
            {
                btnSelected = "Week";
            }
            else
            {
                if (Btn_Month.BackgroundColor == Colorbright)
                    btnSelected = "Month";
            }
            dashboardViewModel.GetData(ddlPlant.SelectedItem.ToString(), btnSelected);
        }

        private void BtnSupport_Clicked(object sender, EventArgs e)
        {
            slSupportNormal.IsVisible = false;
            LvwTicketOpen.IsVisible = true;
            LvwTicketInProcess.IsVisible = true;
            LvwTicketClosed.IsVisible = true;
            HdrOpenLvw.IsVisible = true;
            HdrInProcessLvw.IsVisible = true;
            HdrClosedLvw.IsVisible = true;
            slSupportExpand.IsVisible = true;
        }

        private void BtnAccidents_Clicked(object sender, EventArgs e)
        {

        }

        private void btnOEEUpToDown_Clicked(object sender, EventArgs e)
        {
            OEEExpand.IsVisible = true;
            OEENormal.IsVisible = false;
        }


        private void btnOEEUpToDownExpand_Clicked(object sender, EventArgs e)
        {
            OEEExpand.IsVisible = false;
            OEENormal.IsVisible = true;
        }

        private void BtnSupportUp_Clicked(object sender, EventArgs e)
        {
            slSupportNormal.IsVisible = true;
            LvwTicketOpen.IsVisible = false;
            LvwTicketInProcess.IsVisible = false;
            LvwTicketClosed.IsVisible = false;
            HdrOpenLvw.IsVisible = false;
            HdrInProcessLvw.IsVisible = false;
            HdrClosedLvw.IsVisible = false;
            slSupportExpand.IsVisible = false;
        }

        private void OnPlantSelected(object sender, EventArgs e)
        {
            Picker pick = (Picker)sender;
            if (pick.SelectedIndex == 0)
            {
                ddlPlant.ItemsSource = pick.ItemsSource;
            }
        }

        private void BtnScrap_Clicked(object sender, EventArgs e)
        {
            ScrapExpanded.IsVisible = false;
            ScrapFrame.IsVisible = true;
            MachineStatus.IsVisible = true;
            MachineStatusExpanded.IsVisible = false;
        }

        private void btnScrapExpand_Clicked(object sender, EventArgs e)
        {
            ScrapExpanded.IsVisible = true;
            ScrapFrame.IsVisible = false;
            MachineStatus.IsVisible = false;
            MachineStatusExpanded.IsVisible = true;
        }

        private void OpenItemTapped_Click(object sender, ItemTappedEventArgs e)
        {
            DashboardViewModel vm = (DashboardViewModel)this.BindingContext;
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
            DashboardViewModel vm = (DashboardViewModel)this.BindingContext;
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
            DashboardViewModel vm = (DashboardViewModel)this.BindingContext;
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