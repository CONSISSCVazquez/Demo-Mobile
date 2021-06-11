using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Flexbaze.Models;
using System.Linq;
using System.Collections.ObjectModel;
using Flexbaze.Resources;

namespace Flexbaze.ViewModels
{
    class AlertsViewModel : INotifyPropertyChanged
    {
        private Request _request = new Request();
        private ObservableCollection<Alerts> _listAlerts;
        private Color _btnNewColor;
        private Color _btnAllColor;
        private double _heightListViewSupport;
        private ObservableCollection<Alerts> _filterAlertList;
        private bool _btnNewIsSelected;
        private string _visible = "false";
        public string Visible { get => _visible; set { _visible = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Alerts> ListAlerts
        {
            get => _listAlerts;
            private set
            {
                _listAlerts = value;
                OnPropertyChanged();
            }
        }

        public bool BtnNewIsSelected
        {
            get => _btnNewIsSelected;
            private set
            {
                _btnNewIsSelected = value;
                OnPropertyChanged();
            }
        }

        public double HeightListViewSupport
        {
            get => _heightListViewSupport;
            private set
            {
                _heightListViewSupport = value;
                OnPropertyChanged();
            }
        }

        public Color BtnNewColor
        {
            get => _btnNewColor;
            private set
            {
                _btnNewColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnAllColor
        {
            get => _btnAllColor;
            private set
            {
                _btnAllColor = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Alerts> FilterAlertList
        {
            get => _filterAlertList;
            private set
            {
                _filterAlertList = value;
                OnPropertyChanged();
            }
        }

        public Command FilterAlerts { get; private set; }
        public Command CmdSwipe { get; private set; }
        public Command Refresh { get; private set; }
        public Command GetDetail { get; private set; }

        public AlertsViewModel()
        {
            Ini();
        }

        private void Ini()
        {
            FilterAlerts = new Command((param) => {
                SelectFilterAlerts(param.ToString());
            });
            Refresh = new Command(() => {
                Update();
            });
            GetDetail = new Command((activo) => {
                SeeDetailAlert(activo.ToString());
            });
            CmdSwipe = new Command((alert) => {
                ChangeStatusAlert(alert.ToString());
            });
            Update();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void ChangeStatusAlert(string id)
        {
            foreach (Alerts alert in ListAlerts)
            {
                if (alert.Node == id)
                {
                    alert.IsNew = false;
                    break;
                }
            }

            if (BtnNewIsSelected)
            {
                FilterAlertList.Clear();
                foreach (Alerts al in ListAlerts)
                {
                    if (al.IsNew)
                        FilterAlertList.Add(al);
                }
            }
        }

        private async void SeeDetailAlert(string activo)
        {
            try
            {
                List<Alerts> AlertSelected = new List<Alerts>();
                if (ListAlerts.Count > 0)
                {

                    AlertSelected = ListAlerts.Where((Alerts alert) =>
                    {
                        return (alert.Node == activo) ? true : false;
                    }).ToList();
                    if (AlertSelected.Count == 1)
                    {
                        App.MasterDP.IsPresented = false;
                        Alerts param = AlertSelected[0];
                        await App.MasterDP.Detail.Navigation.PushAsync(new Views.DetalleAlerta(param));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SelectFilterAlerts(string param)
        {
            FilterAlertList.Clear();
            if (param.Equals("all"))
            {
                foreach (Alerts alert in ListAlerts)
                    FilterAlertList.Add(alert);
                BtnNewIsSelected = false;
                BtnAllColor = Color.FromHex("#336ef4");
                BtnNewColor = Color.Transparent;
            }
            else
            {
                foreach (Alerts alert in ListAlerts)
                {
                    if (alert.IsNew)
                        FilterAlertList.Add(alert);
                }
                BtnNewIsSelected = true;
                BtnNewColor = Color.FromHex("#336ef4");
                BtnAllColor = Color.Transparent;
            }
        }

        private void Update()
        {
            try
            {
                //string json = await _request.GetData("app", "{\"metodo\": \"app_vistaAlertas\",\"attr\": {\"clave\":\"" + Settings.Client + "\",\"show\": \"" + Settings.ShowAlerts + "\"}}");
                //if (json != "-1000")
                //{
                //    AlertsModel result = JsonConvert.DeserializeObject<AlertsModel>(json);
                //    ListAlerts = result.Result;
                //    if (ListAlerts.Count > 0)
                //    {
                //        ListAlerts.ForEach((Alerts alert) =>
                //        {
                //            if (alert.Leido == "1")
                //                alert.Leido = "read.png";
                //            else
                //                alert.Leido = "unread.png";
                //            alert.GetDetail = GetDetail;

                //            if (int.Parse(alert.MsgCount) > 0)
                //            {
                //                alert.HasMessages = true;
                //            }
                //            else
                //            {
                //                alert.MsgCount = string.Empty;
                //                alert.HasMessages = false;
                //            }
                //        });
                //    }
                //    else
                //        Visible = "true";
                //}
                ListAlerts = new ObservableCollection<Alerts>();
                FilterAlertList = new ObservableCollection<Alerts>();
                Alerts alert1 = new Alerts()
                {
                    Node = "1",
                    TimeLapse = AppResources.FiveMinutes,
                    Status = "2",
                    Icon = "caution.png",
                    MsgCard = AppResources.SecurityLabel,
                    IsNew = true,
                    Message = AppResources.InjuredUser,
                    CmdSwipe = CmdSwipe
                };
                Alerts alert2 = new Alerts()
                {
                    Node = "2",
                    TimeLapse = AppResources.OneHour,
                    Status = "1",
                    Icon = "plant.png",
                    MsgCard = AppResources.CellLabel + " 2",
                    IsNew = true,
                    Message = AppResources.MinusSpeed,
                    CmdSwipe = CmdSwipe
                };
                Alerts alert3 = new Alerts()
                {
                    Node = "3",
                    TimeLapse = AppResources.OneHour,
                    Status = "0",
                    Icon = "plant.png",
                    MsgCard = AppResources.CellLabel + " 1",
                    IsNew = true,
                    Message = AppResources.TicketLabel + " 139 " + AppResources.TicketClosed,
                    CmdSwipe = CmdSwipe
                };
                Alerts alert4 = new Alerts()
                {
                    Node = "4",
                    TimeLapse = AppResources.YesterdayLabel + " 07:45",
                    Status = "1",
                    Icon = "plant.png",
                    MsgCard = AppResources.CellLabel + " 1",
                    IsNew = true,
                    Message = AppResources.LackMaterial + " " + AppResources.InLabel + " M101. " + AppResources.StoppedProduction,
                    CmdSwipe = CmdSwipe
                };
                Alerts alert5 = new Alerts()
                {
                    Node = "5",
                    TimeLapse = AppResources.YesterdayLabel + " 10:23",
                    Status = "1",
                    Icon = "plant.png",
                    MsgCard = AppResources.CellLabel + " 2",
                    IsNew = false,
                    Message = AppResources.LackMaterial + " " + AppResources.InLabel + " M401. " + AppResources.StoppedProduction,
                    CmdSwipe = CmdSwipe
                };
                Alerts alert6 = new Alerts()
                {
                    Node = "6",
                    TimeLapse = AppResources.FourteenMinutes,
                    Status = "0",
                    Icon = "plant.png",
                    MsgCard = AppResources.CellLabel + " 2",
                    IsNew = false,
                    Message = AppResources.TicketLabel + " 145 " + AppResources.TicketClosed,
                    CmdSwipe = CmdSwipe
                };
                ListAlerts.Add(alert1);
                ListAlerts.Add(alert2);
                ListAlerts.Add(alert3);
                ListAlerts.Add(alert4);
                ListAlerts.Add(alert5);
                ListAlerts.Add(alert6);
                FilterAlertList.Add(alert1);
                FilterAlertList.Add(alert2);
                FilterAlertList.Add(alert3);
                FilterAlertList.Add(alert4);
                HeightListViewSupport = (100 * FilterAlertList.Count) + 10;
                BtnNewIsSelected = true;
                BtnNewColor = Color.FromHex("#336ef4");
                BtnAllColor = Color.Transparent;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }
}
