using Flexbaze.Models;
using Flexbaze.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OEEMachines : ContentPage
    {
        private OEEMachinesViewModel oeeViewModel;
        public OEEMachines()
        {
            InitializeComponent();
            Ini();
        }

        private void Ini()
        {
            oeeViewModel = new OEEMachinesViewModel();
            BindingContext = oeeViewModel;
        }

        private void MnuDashboard_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Dashboard()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuSupport_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            App.Current.MainPage = new NavigationPage(new Chronology()) { BarBackgroundColor = Color.FromHex("#101630") };
        }

        private void MnuOEE_Clicked(object sender, EventArgs e)
        {
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

        private void OnSortSelected(object sender, EventArgs e)
        {
            OEEMachinesViewModel vm = (OEEMachinesViewModel)BindingContext;
            ObservableCollection<OEEMachine> auxList = new ObservableCollection<OEEMachine>();
            Picker pick = (Picker)sender;
            FactoryType sortSelected = (FactoryType)pick.ItemsSource[pick.SelectedIndex];
            FactoryType familySelected = new FactoryType();

            if (ddlFamily.ItemsSource != null)
                familySelected = (FactoryType)ddlFamily.ItemsSource[ddlFamily.SelectedIndex];
            else
                return;

            vm.FilterOEEMachines(sortSelected.Name, familySelected.Name);
            AdjustLabel();
        }

        private void OnFamilyMachineSelected(object sender, EventArgs e)
        {
            OEEMachinesViewModel vm = (OEEMachinesViewModel)BindingContext;
            ObservableCollection<OEEMachine> auxList = new ObservableCollection<OEEMachine>();
            Picker pick = (Picker)sender;
            FactoryType familySelected = (FactoryType)pick.ItemsSource[pick.SelectedIndex];
            FactoryType sortSelected = (FactoryType)ddlSort.ItemsSource[ddlSort.SelectedIndex];

            vm.FilterOEEMachines(sortSelected.Name, familySelected.Name);
            AdjustLabel();
        }

        private void AdjustLabel()
        {
            OEEMachinesViewModel vm = (OEEMachinesViewModel)BindingContext;
            if (vm.QtyInProduction == 0 && vm.QtyWithoutProducing > 0)
                bxvGray.Margin = new Thickness(18, 5, -5, 0);
            else
                bxvGray.Margin = new Thickness(20, 5, -5, 0);
        }

        private void BtnSearch_Clicked(object sender, EventArgs e)
        {
            slContainer.HeightRequest = 70;
            frmSearchExpanded.IsVisible = true;
            btnSearch.IsVisible = false;
        }

        private void BtnSearchExpanded_Clicked(object sender, EventArgs e)
        {
            slContainer.HeightRequest = 40;
            frmSearchExpanded.IsVisible = false;
            btnSearch.IsVisible = true;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            OEEMachinesViewModel vm = (OEEMachinesViewModel)BindingContext;
            FactoryType familySelected = (FactoryType)ddlFamily.ItemsSource[ddlFamily.SelectedIndex];
            FactoryType sortSelected = (FactoryType)ddlSort.ItemsSource[ddlSort.SelectedIndex];
            vm.searchMachine(entry.Text, sortSelected.Name, familySelected.Name);
            AdjustLabel();
        }
    }
}