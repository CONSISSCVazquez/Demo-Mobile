using Flexbaze.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Flexbaze.Resources;
using Flexbaze.Views;
using System.Windows.Input;

namespace Flexbaze.ViewModels
{
    class ChronologyViewModel : INotifyPropertyChanged
    {
        private Request _request = new Request();
        private ObservableCollection<Ticket> _openTicketList;
        private ObservableCollection<Ticket> _inProcessTicketList;
        private ObservableCollection<Ticket> _closedTicketList;
        private ObservableCollection<Ticket> _filterTicketList;
        private Color _btnOpenColor;
        private Color _btnInProcessColor;
        private Color _btnDoneColor;
        private bool _btnOpenIsSelected;
        private bool _btnInProcessIsSelected;
        private bool _btnDoneIsSelected;
        private double _heightLvwOpen;
        private double _heightLvwInProcess;
        private double _heightLvwClosed;
        private double _widthScreen;
        private string _statusSelected;
        private string _period;
        private int _qtyOpen;
        private int _qtyInProcess;
        private int _qtyClosed;
        private Ticket _openSelectedItem;
        private List<string> _plantList;
        private List<string> _cellList;
        private string _plantSelected;
        private string _cellSelected;
        public Command CmdTickets { get; set; }
        public Command CmdSelected { get; set; }
        public ICommand CmdAssign { get; set; }
        public ICommand CmdViewDetails { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Ticket> OpenTicketList
        {
            get => _openTicketList;
            private set
            {
                _openTicketList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Ticket> InProcessTicketList
        {
            get => _inProcessTicketList;
            private set
            {
                _inProcessTicketList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Ticket> ClosedTicketList
        {
            get => _closedTicketList;
            private set
            {
                _closedTicketList = value;
                OnPropertyChanged();
            }
        }

        public Ticket OpenSelectedItem
        {
            get => _openSelectedItem;
            private set
            {
                _openSelectedItem = value;
                OnPropertyChanged();
            }
        }

        public double WidthScreen
        {
            get => _widthScreen;
            private set
            {
                _widthScreen = value;
                OnPropertyChanged();
            }
        }

        public List<string> PlantList
        {
            get => _plantList;
            private set
            {
                _plantList = value;
                OnPropertyChanged();
            }
        }

        public List<string> CellList
        {
            get => _cellList;
            private set
            {
                _cellList = value;
                OnPropertyChanged();
            }
        }

        public string PlantSelected
        {
            get => _plantSelected;
            private set
            {
                _plantSelected = value;
                OnPropertyChanged();
            }
        }

        public string CellSelected
        {
            get => _cellSelected;
            private set
            {
                _cellSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Ticket> FilterTicketList
        {
            get => _filterTicketList;
            private set
            {
                _filterTicketList = value;
                OnPropertyChanged();
            }
        }

        public Color BtnOpenColor
        {
            get => _btnOpenColor;
            private set
            {
                _btnOpenColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnInProcessColor
        {
            get => _btnInProcessColor;
            private set
            {
                _btnInProcessColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnDoneColor
        {
            get => _btnDoneColor;
            private set
            {
                _btnDoneColor = value;
                OnPropertyChanged();
            }
        }

        public bool BtnOpenIsSelected
        {
            get => _btnOpenIsSelected;
            private set
            {
                _btnOpenIsSelected = value;
                OnPropertyChanged();
            }
        }

        public bool BtnInProcessIsSelected
        {
            get => _btnInProcessIsSelected;
            private set
            {
                _btnInProcessIsSelected = value;
                OnPropertyChanged();
            }
        }

        public bool BtnDoneIsSelected
        {
            get => _btnDoneIsSelected;
            private set
            {
                _btnDoneIsSelected = value;
                OnPropertyChanged();
            }
        }

        public double HeightLvwOpen
        {
            get => _heightLvwOpen;
            private set
            {
                _heightLvwOpen = value;
                OnPropertyChanged();
            }
        }

        public double HeightLvwInProcess
        {
            get => _heightLvwInProcess;
            private set
            {
                _heightLvwInProcess = value;
                OnPropertyChanged();
            }
        }

        public double HeightLvwClosed
        {
            get => _heightLvwClosed;
            private set
            {
                _heightLvwClosed = value;
                OnPropertyChanged();
            }
        }

        public string StatusSelected
        {
            get => _statusSelected;
            private set
            {
                _statusSelected = value;
                OnPropertyChanged();
            }
        }

        public int QtyOpen
        {
            get => _qtyOpen;
            private set
            {
                _qtyOpen = value;
                OnPropertyChanged();
            }
        }

        public int QtyInProcess
        {
            get => _qtyInProcess;
            private set
            {
                _qtyInProcess = value;
                OnPropertyChanged();
            }
        }

        public int QtyClosed
        {
            get => _qtyClosed;
            private set
            {
                _qtyClosed = value;
                OnPropertyChanged();
            }
        }

        public string Period
        {
            get => _period;
            private set
            {
                _period = value;
                OnPropertyChanged();
            }
        }

        public ChronologyViewModel()
        {
            Ini();
        }

        private void Ini()
        {
            LoadTickets();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void LoadTickets()
        {
            WidthScreen = App.ScreenWidth;
            PlantList = new List<string>();
            CellList = new List<string>();
            CmdSelected = new Command((param) =>
                    SelectedTicket((Ticket)param));
            CmdAssign = new Command((param) =>
                    AssignTicket(param.ToString()));
            CmdViewDetails = new Command((param) =>
                    ViewDetails(param.ToString()));
            OpenTicketList = new ObservableCollection<Ticket>();
            InProcessTicketList = new ObservableCollection<Ticket>();
            ClosedTicketList = new ObservableCollection<Ticket>();
            FilterTicketList = new ObservableCollection<Ticket>();
            Ticket ticket1 = new Ticket()
            {
                Id = "1",
                Status = "Abierto",
                ImgStatus = "open.png",
                Description = AppResources.LackMaterial,
                Hour = "10:12 AM",
                Machine = "M101",
                OEE = "96%",
                Cell = "C1",
                TextButton = AppResources.AssignLabel,
                Progress = new Rectangle(19, 30, 2, 40),
                IsSelected = false,
                ButtonBorder = "#336EF4",
                CmdName = "CmdAssign",
                CmdButton = (Command)CmdAssign
            };
            Ticket ticket2 = new Ticket()
            {
                Id = "2",
                Status = "Abierto",
                ImgStatus = "open.png",
                Description = AppResources.FailureMold + " 392",
                Hour = "10:12 AM",
                Machine = "M301",
                OEE = "96%",
                Cell = "C1",
                TextButton = AppResources.AssignLabel,
                Progress = new Rectangle(19, 0, 2, 35),
                IsSelected = false,
                ButtonBorder = "#336EF4",
                CmdName = "CmdAssign",
                CmdButton = (Command)CmdAssign
            };
            Ticket ticket3 = new Ticket()
            {
                Id = "3",
                Status = "En Proceso",
                ImgStatus = "clock.png",
                Description = AppResources.Maintenance,
                Hour = "10:12 AM",
                Machine = "M101",
                OEE = "96%",
                Cell = "C1",
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 30, 2, 40),
                IsSelected = false,
                ButtonBorder = "#F88300",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            Ticket ticket4 = new Ticket()
            {
                Id = "4",
                Status = "En Proceso",
                ImgStatus = "clock.png",
                Description = AppResources.LeakLabel,
                Hour = "10:12 AM",
                Machine = "M301",
                OEE = "96%",
                Cell = "C1",
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 0, 2, 70),
                IsSelected = false,
                ButtonBorder = "#F88300",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            Ticket ticket5 = new Ticket()
            {
                Id = "5",
                Status = "En Proceso",
                ImgStatus = "clock.png",
                Description = AppResources.MinorIncident,
                Hour = "10:12 AM",
                Machine = "M101",
                OEE = "96%",
                Cell = "C1",
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 0, 2, 35),
                IsSelected = false,
                ButtonBorder = "#F88300",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            Ticket ticket6 = new Ticket()
            {
                Id = "6",
                Status = "Cerrado",
                ImgStatus = "done.png",
                Description = AppResources.LackMaterial,
                Hour = "10:12 AM",
                Machine = "M101",
                OEE = "96%",
                Cell = "C1",
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 30, 0, 0),
                IsSelected = false,
                ButtonBorder = "#36A889",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };

            OpenTicketList.Add(ticket1);
            OpenTicketList.Add(ticket2);
            InProcessTicketList.Add(ticket3);
            InProcessTicketList.Add(ticket4);
            InProcessTicketList.Add(ticket5);
            ClosedTicketList.Add(ticket6);
            HeightLvwOpen = (65 * OpenTicketList.Count) + 10;
            HeightLvwInProcess = (65 * InProcessTicketList.Count) + 10;
            HeightLvwClosed = (65 * ClosedTicketList.Count) + 10;
            QtyOpen = OpenTicketList.Count;
            QtyInProcess = InProcessTicketList.Count;
            QtyClosed = ClosedTicketList.Count;
            StatusSelected = "Open";
            CmdTickets = new Command((param) =>
                            FilterTickets(param.ToString()));
            FilterTickets("open");
            BtnOpenColor = Color.FromHex("#336ef4");
            BtnInProcessColor = Color.Transparent;
            BtnDoneColor = Color.Transparent;
            BtnOpenIsSelected = true;
            BtnInProcessIsSelected = false;
            BtnDoneIsSelected = false;
            PlantList.Add("General");
            PlantList.Add("M1");
            PlantList.Add("M2");
            PlantList.Add("M3");
            PlantSelected = "General";
            CellList.Add(AppResources.AllCells);
            CellList.Add(AppResources.CellLabel + " 1");
            CellList.Add(AppResources.CellLabel + " 2");
            CellList.Add(AppResources.CellLabel + " 3");
            CellList.Add(AppResources.CellLabel + " 4");
            CellList.Add(AppResources.CellLabel + " 5");
            CellSelected = AppResources.AllCells;
            Period = "Hoy";
        }

        public void SelectedTicket(Ticket t)
        {
            if (t != null)
            {
                if (t.IsSelected)
                {
                    t.IsSelected = false;
                    OpenSelectedItem = null;
                    return;
                }
                else
                {
                    t.IsSelected = true;
                    OpenSelectedItem = t;
                    return;
                }
            }
        }

        public async void ViewDetails(string ticketId)
        {
            string status = GetStatus(ticketId);
            await App.MasterDP.Detail.Navigation.PushAsync(new SupportDetail(ticketId, status));
        }

        public string GetStatus(string ticketId)
        {
            string status = string.Empty;
            if (BtnInProcessIsSelected)
            {
                foreach (Ticket t in InProcessTicketList)
                {
                    if (t.Id == ticketId)
                    {
                        return AppResources.InProcessLabel;
                    }
                }
            }
            if (BtnDoneIsSelected)
            {
                foreach (Ticket t in ClosedTicketList)
                {
                    if (t.Id == ticketId)
                    {
                        return AppResources.ClosedLabel;
                    }
                }
            }
            return status;
        }

        public void AssignTicket(string ticketId)
        {
            Console.WriteLine(ticketId);
        }
        public void FilterTickets(string filter)
        {
            switch(filter)
            {
                case "open":
                    if (BtnOpenIsSelected)
                    {
                        //Review this is not the unique button selected
                        if (BtnInProcessIsSelected || BtnDoneIsSelected)
                        {
                            BtnOpenIsSelected = false;
                            BtnOpenColor = Color.Transparent;
                        }
                    }  
                    else
                    {
                        BtnOpenIsSelected = true;
                        BtnOpenColor = Color.FromHex("#336ef4");
                    }
                    break;
                case "inProcess":
                    if (BtnInProcessIsSelected)
                    {
                        if (BtnOpenIsSelected || BtnDoneIsSelected)
                        {
                            BtnInProcessIsSelected = false;
                            BtnInProcessColor = Color.Transparent;
                        }
                    }
                    else
                    {
                        BtnInProcessIsSelected = true;
                        BtnInProcessColor = Color.FromHex("#ea8800");
                    }
                    break;
                case "done":
                    if (BtnDoneIsSelected)
                    {
                        if (BtnOpenIsSelected || BtnInProcessIsSelected)
                        {
                            BtnDoneIsSelected = false;
                            BtnDoneColor = Color.Transparent;
                        }
                    }
                    else
                    {
                        BtnDoneIsSelected = true;
                        BtnDoneColor = Color.FromHex("#00a889");
                    }        
                    break;
            }
        }
    }
}