using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using Flexbaze.ViewModels;
using Flexbaze.Models;
using System.Collections.ObjectModel;
using static Flexbaze.ViewModels.DashboardViewModel;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage, INavigationHandler
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
            ReloadCharts();
        }

        private void Ini()
        {
            dashboardViewModel = new DashboardViewModel(this);
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
            dashboardViewModel.LoadScrap(Planning.Today);
            dashboardViewModel.LoadEntries(Planning.Today);
            ReloadCharts();
        }

        private void BtnWeek_Clicked(object sender, EventArgs e)
        {
            Btn_Today.BackgroundColor = Colormain;
            Btn_Week.BackgroundColor = Colorbright;
            Btn_Month.BackgroundColor = Colormain;
            dashboardViewModel.LoadScrap(Planning.Week);
            dashboardViewModel.LoadEntries(Planning.Week);
            ReloadCharts();
        }

        private void BtnMonth_Clicked(object sender, EventArgs e)
        {
            Btn_Today.BackgroundColor = Colormain;
            Btn_Week.BackgroundColor = Colormain;
            Btn_Month.BackgroundColor = Colorbright;
            dashboardViewModel.LoadScrap(Planning.Month);
            dashboardViewModel.LoadEntries(Planning.Month);
            ReloadCharts();
        }

        private void BtnOEE_Clicked(object sender, EventArgs e)
        {

        }

        private void ReloadCharts()
        {
            barChart.Chart = new BarChart()
            {
                Entries = dashboardViewModel.EntryList,
                BackgroundColor = SKColor.Parse("#00FFFFFF"),
                LabelTextSize = 30,
                ValueLabelOrientation = Orientation.Horizontal,
                BarAreaAlpha = 0
            };

            scrapChart.Chart = new BarChart()
            {
                Entries = dashboardViewModel.EntryList,
                BackgroundColor = SKColor.Parse("#00FFFFFF"),
                LabelTextSize = 30,
                ValueLabelOrientation = Orientation.Horizontal,
                BarAreaAlpha = 0
            };
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
            DashboardViewModel vm = (DashboardViewModel)BindingContext;
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
            DashboardViewModel vm = (DashboardViewModel)BindingContext;
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
            DashboardViewModel vm = (DashboardViewModel)BindingContext;
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
        }

        private void MnuSupport_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Chronology()) { BarBackgroundColor = Color.FromHex("#101630") };
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