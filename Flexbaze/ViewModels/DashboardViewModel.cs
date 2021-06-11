using Microcharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using SkiaSharp;
using System.Runtime.CompilerServices;
using Flexbaze.Models;
using Xamarin.Forms;
using Cell = Flexbaze.Models.Cell;
using System.Collections.ObjectModel;
using Flexbaze.Resources;
using Flexbaze.Views;

namespace Flexbaze.ViewModels
{
    class DashboardViewModel : INotifyPropertyChanged
    {
        private Request _request = new Request();
        private List<ChartEntry> _entryList;
        private List<ChartEntry> _entryCausesList;
        private ObservableCollection<Cell> _cellList;
        private ObservableCollection<Stoppage> _stopList;
        private ObservableCollection<Scrap> _scrapList;
        private ObservableCollection<Ticket> _openTicketList;
        private ObservableCollection<Ticket> _inProcessTicketList;
        private ObservableCollection<Ticket> _closedTicketList;
        private List<Ticket> _filterTicketList;
        private List<string> _plantList;
        private string _plantSelected;
        private double _heightListViewOEE;
        private double _heightListViewOpen;
        private double _heightListViewInProcess;
        private double _heightListViewClosed;
        private string _orderName;
        private string _orderProgress;
        private string _orderOEE;
        private string _orderMetrics;
        private int _accidents;
        private int _incidents;
        private bool _showAccidents;
        private string _bestTeamLeaderCell;
        private string _oeePlantHdr;
        public Command CmdOrder { get; private set; }
        public Command CmdAssign { get; private set; }
        public Command CmdViewDetails { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<ChartEntry> EntryList
        {
            get => _entryList;
            private set
            {
                _entryList = value;
                OnPropertyChanged();
            }
        }

        public List<ChartEntry> EntryCausesList
        {
            get => _entryCausesList;
            private set
            {
                _entryCausesList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Cell> CellList
        {
            get => _cellList;
            private set
            {
                _cellList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Stoppage> StopList
        {
            get => _stopList;
            private set
            {
                _stopList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Scrap> ScrapList
        {
            get => _scrapList;
            private set
            {
                _scrapList = value;
                OnPropertyChanged();
            }
        }

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

        public List<string> PlantList
        {
            get => _plantList;
            private set
            {
                _plantList = value;
                OnPropertyChanged();
            }
        }

        public List<Ticket> FilterTicketList
        {
            get => _filterTicketList;
            private set
            {
                _filterTicketList = value;
                OnPropertyChanged();
            }
        }

        public double HeightListViewOEE
        {
            get => _heightListViewOEE;
            private set
            {
                _heightListViewOEE = value;
                OnPropertyChanged();
            }
        }

        public double HeightListViewOpen
        {
            get => _heightListViewOpen;
            private set
            {
                _heightListViewOpen = value;
                OnPropertyChanged();
            }
        }

        public double HeightListViewInProcess
        {
            get => _heightListViewInProcess;
            private set
            {
                _heightListViewInProcess = value;
                OnPropertyChanged();
            }
        }

        public double HeightListViewClosed
        {
            get => _heightListViewClosed;
            private set
            {
                _heightListViewClosed = value;
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

        public string OrderName
        {
            get => _orderName;
            private set
            {
                _orderName = value;
                OnPropertyChanged();
            }
        }
        public string OrderProgress
        {
            get => _orderProgress;
            private set
            {
                _orderProgress = value;
                OnPropertyChanged();
            }
        }

        public string OrderOEE
        {
            get => _orderOEE;
            private set
            {
                _orderOEE = value;
                OnPropertyChanged();
            }
        }

        public string OrderMetrics
        {
            get => _orderMetrics;
            private set
            {
                _orderMetrics = value;
                OnPropertyChanged();
            }
        }

        public int Accidents
        {
            get => _accidents;
            private set
            {
                _accidents = value;
                OnPropertyChanged();
            }
        }

        public int Incidents
        {
            get => _incidents;
            private set
            {
                _incidents = value;
                OnPropertyChanged();
            }
        }

        public bool ShowAccidents
        {
            get => _showAccidents;
            private set
            {
                _showAccidents = value;
                OnPropertyChanged();
            }
        }

        public string BestTeamLeaderCell
        {
            get => _bestTeamLeaderCell;
            private set
            {
                _bestTeamLeaderCell = value;
                OnPropertyChanged();
            }
        }

        public string OEEPlantHdr
        {
            get => _oeePlantHdr;
            private set
            {
                _oeePlantHdr = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel()
        {
            Ini();
        }

        private void Ini()
        {
            LoadDropDown();
            GetData("M1", "Today");
        }

        public void GetData(string plant, string period)
        {
            GetAccidents(plant, period);
            LoadEntries(plant, period);
            LoadScrap(plant, period);
            LoadOEEUpToDown(plant, period);
            LoadTickets(plant, period);
            GetBestTeamLeaderCell(plant, period);
            OEEPlantHdr = "OEE " + AppResources.PlantLabel + " " + plant;
            if (Accidents == 0 && Incidents == 0)
                ShowAccidents = false;
            else
                ShowAccidents = true;
        }

        private void GetBestTeamLeaderCell(string plant, string period)
        {
            switch(plant)
            {
                case "M1":
                    switch (period)
                    {
                        case "Today":
                            BestTeamLeaderCell = AppResources.CellLabel + " 1";
                            break;
                        case "Week":
                            BestTeamLeaderCell = AppResources.CellLabel + " 4";
                            break;
                        case "Month":
                            BestTeamLeaderCell = AppResources.CellLabel + " 7";
                            break;
                    }
                    break;
                case "M2":
                    switch (period)
                    {
                        case "Today":
                            BestTeamLeaderCell = AppResources.CellLabel + " 2";
                            break;
                        case "Week":
                            BestTeamLeaderCell = AppResources.CellLabel + " 5";
                            break;
                        case "Month":
                            BestTeamLeaderCell = AppResources.CellLabel + " 8";
                            break;
                    }
                    break;
                case "M3":
                    switch (period)
                    {
                        case "Today":
                            BestTeamLeaderCell = AppResources.CellLabel + " 3";
                            break;
                        case "Week":
                            BestTeamLeaderCell = AppResources.CellLabel + " 6";
                            break;
                        case "Month":
                            BestTeamLeaderCell = AppResources.CellLabel + " 9";
                            break;
                    }
                    break;
            }
        }

        public void GetAccidents(string plant, string period)
        {
            switch (plant)
            {
                case "M1":
                    switch (period)
                    {
                        case "Today":
                            Accidents = 1;
                            Incidents = 0;
                            break;
                        case "Week":
                            Accidents = 2;
                            Incidents = 1;
                            break;
                        case "Month":
                            Accidents = 0;
                            Incidents = 1;
                            break;
                    }
                    break;
                case "M2":
                    switch (period)
                    {
                        case "Today":
                            Accidents = 0;
                            Incidents = 0;
                            break;
                        case "Week":
                            Accidents = 1;
                            Incidents = 1;
                            break;
                        case "Month":
                            Accidents = 3;
                            Incidents = 1;
                            break;
                    }
                    break;
                case "M3":
                    switch (period)
                    {
                        case "Today":
                            Accidents = 4;
                            Incidents = 2;
                            break;
                        case "Week":
                            Accidents = 0;
                            Incidents = 3;
                            break;
                        case "Month":
                            Accidents = 0;
                            Incidents = 0;
                            break;
                    }
                    break;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void LoadEntries(string plant, string period)
        {
            EntryList = new List<ChartEntry>();
            EntryCausesList = new List<ChartEntry>();
            StopList = new ObservableCollection<Stoppage>();
            Stoppage stop1 = new Stoppage()
            {
                ColorLabel = Color.FromHex("#2BB9F1"),
                Name = AppResources.RawMaterial,
                Percentage = "25%"
            };
            ChartEntry ent1 = new ChartEntry(25)
            {
                Label = " ",
                ValueLabel = "25%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#2BB9F1"),
                TextColor = SKColors.White
            };
            Stoppage stop2 = new Stoppage()
            {
                ColorLabel = Color.FromHex("#A509D0"),
                Name = "Setup CM",
                Percentage = "12%"
            };
            ChartEntry ent2 = new ChartEntry(12)
            {
                Label = " ",
                ValueLabel = "12%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#A509D0"),
                TextColor = SKColors.White
            };
            Stoppage stop3 = new Stoppage()
            {
                ColorLabel = Color.FromHex("#E26716"),
                Name = AppResources.LackMold,
                Percentage = "10%"
            };
            ChartEntry ent3 = new ChartEntry(10)
            {
                Label = " ",
                ValueLabel = "10%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#E26716"),
                TextColor = SKColors.White
            };
            Stoppage stop4 = new Stoppage()
            {
                ColorLabel = Color.FromHex("#5228EA"),
                Name = AppResources.MoldRoutine,
                Percentage = "9%"
            };
            ChartEntry ent4 = new ChartEntry(9)
            {
                Label = " ",
                ValueLabel = "9%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#5228EA"),
                TextColor = SKColors.White
            };
            Stoppage stop5 = new Stoppage()
            {
                ColorLabel = Color.FromHex("#71BD4E"),
                Name = AppResources.PackedLabel,
                Percentage = "6%"
            };
            ChartEntry ent5 = new ChartEntry(6)
            {
                Label = " ",
                ValueLabel = "6%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#71BD4E"),
                TextColor = SKColors.White
            };
            ChartEntry ent6 = new ChartEntry(28)
            {
                Label = " ",
                ValueLabel = "28%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#2BB9F1"),
                TextColor = SKColors.White
            };
            ChartEntry ent7 = new ChartEntry(22)
            {
                Label = " ",
                ValueLabel = "22%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#A509D0"),
                TextColor = SKColors.White
            };
            ChartEntry ent8 = new ChartEntry(17)
            {
                Label = " ",
                ValueLabel = "17%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#E26716"),
                TextColor = SKColors.White
            };
            ChartEntry ent9 = new ChartEntry(33)
            {
                Label = " ",
                ValueLabel = "33%",
                ValueLabelColor = SKColors.White,
                Color = SKColor.Parse("#5228EA"),
                TextColor = SKColors.White
            };
            switch (plant)
            {
                case "M1":
                    switch (period)
                    {
                        case "Today":
                            EntryList.Add(ent1);
                            EntryList.Add(ent4);
                            EntryCausesList.Add(ent6);
                            EntryCausesList.Add(ent8);
                            StopList.Add(stop1);
                            StopList.Add(stop3);
                            break;
                        case "Week":
                            EntryList.Add(ent1);
                            EntryList.Add(ent2);
                            EntryList.Add(ent4);
                            EntryCausesList.Add(ent6);
                            EntryCausesList.Add(ent7);
                            EntryCausesList.Add(ent8);
                            StopList.Add(stop1);
                            StopList.Add(stop2);
                            StopList.Add(stop3);
                            break;
                        case "Month":
                            EntryList.Add(ent1);
                            EntryList.Add(ent2);
                            EntryList.Add(ent3);
                            EntryList.Add(ent4);
                            EntryList.Add(ent5);
                            EntryCausesList.Add(ent6);
                            EntryCausesList.Add(ent7);
                            EntryCausesList.Add(ent8);
                            EntryCausesList.Add(ent9);
                            StopList.Add(stop1);
                            StopList.Add(stop2);
                            StopList.Add(stop3);
                            StopList.Add(stop4);
                            StopList.Add(stop5);
                            break;
                    }
                    break;
                case "M2":
                    switch (period)
                    {
                        case "Today":
                            EntryList.Add(ent2);
                            EntryList.Add(ent3);
                            EntryCausesList.Add(ent8);
                            EntryCausesList.Add(ent7);
                            StopList.Add(stop2);
                            StopList.Add(stop4);
                            break;
                        case "Week":
                            EntryList.Add(ent2);
                            EntryList.Add(ent3);
                            EntryList.Add(ent5);
                            EntryCausesList.Add(ent8);
                            EntryCausesList.Add(ent7);
                            EntryCausesList.Add(ent9);
                            StopList.Add(stop2);
                            StopList.Add(stop4);
                            StopList.Add(stop5);
                            break;
                        case "Month":
                            EntryList.Add(ent2);
                            EntryList.Add(ent3);
                            EntryList.Add(ent5);
                            EntryList.Add(ent4);
                            EntryList.Add(ent1);
                            EntryCausesList.Add(ent8);
                            EntryCausesList.Add(ent7);
                            EntryCausesList.Add(ent9);
                            EntryCausesList.Add(ent6);
                            StopList.Add(stop2);
                            StopList.Add(stop4);
                            StopList.Add(stop5);
                            StopList.Add(stop1);
                            StopList.Add(stop3);
                            break;
                    }
                    break;
                case "M3":
                    switch (period)
                    {
                        case "Today":
                            EntryList.Add(ent5);
                            EntryList.Add(ent1);
                            EntryCausesList.Add(ent9);
                            EntryCausesList.Add(ent6);
                            StopList.Add(stop5);
                            StopList.Add(stop1);
                            break;
                        case "Week":
                            EntryList.Add(ent5);
                            EntryList.Add(ent1);
                            EntryList.Add(ent4);
                            EntryCausesList.Add(ent9);
                            EntryCausesList.Add(ent6);
                            EntryCausesList.Add(ent8);
                            StopList.Add(stop5);
                            StopList.Add(stop1);
                            StopList.Add(stop3);
                            break;
                        case "Month":
                            EntryList.Add(ent5);
                            EntryList.Add(ent1);
                            EntryList.Add(ent4);
                            EntryList.Add(ent3);
                            EntryList.Add(ent2);
                            EntryCausesList.Add(ent9);
                            EntryCausesList.Add(ent6);
                            EntryCausesList.Add(ent8);
                            EntryCausesList.Add(ent7);
                            StopList.Add(stop5);
                            StopList.Add(stop1);
                            StopList.Add(stop3);
                            StopList.Add(stop2);
                            StopList.Add(stop4);
                            break;
                    }
                    break;
            }
        }

        private void LoadScrap(string plant, string period)
        {
            ScrapList = new ObservableCollection<Scrap>();
            Scrap scrap1 = new Scrap()
            {
                ColorLabel = Color.FromHex("#2BB9F1"),
                Name = AppResources.MilkyPiece,
                Percentage = "28%"
            };
            Scrap scrap2 = new Scrap()
            {
                ColorLabel = Color.FromHex("#A509D0"),
                Name = AppResources.MeasuresNotAllowed,
                Percentage = "22%"
            };
            Scrap scrap3 = new Scrap()
            {
                ColorLabel = Color.FromHex("#E26716"),
                Name = AppResources.BrokenPiece,
                Percentage = "17%"
            };
            Scrap scrap4 = new Scrap()
            {
                ColorLabel = Color.FromHex("#5228EA"),
                Name = AppResources.PigmentNeeded,
                Percentage = "33%"
            };
            switch (plant)
            {
                case "M1":
                    switch (period)
                    {
                        case "Today":
                            ScrapList.Add(scrap1);
                            ScrapList.Add(scrap2);
                            break;
                        case "Week":
                            ScrapList.Add(scrap1);
                            ScrapList.Add(scrap2);
                            ScrapList.Add(scrap3);
                            break;
                        case "Month":
                            ScrapList.Add(scrap1);
                            ScrapList.Add(scrap2);
                            ScrapList.Add(scrap3);
                            ScrapList.Add(scrap4);
                            break;
                    }
                    break;
                case "M2":
                    switch (period)
                    {
                        case "Today":
                            ScrapList.Add(scrap2);
                            ScrapList.Add(scrap3);
                            break;
                        case "Week":
                            ScrapList.Add(scrap2);
                            ScrapList.Add(scrap3);
                            ScrapList.Add(scrap4);
                            break;
                        case "Month":
                            ScrapList.Add(scrap2);
                            ScrapList.Add(scrap3);
                            ScrapList.Add(scrap4);
                            ScrapList.Add(scrap1);
                            break;
                    }
                    break;
                case "M3":
                    switch (period)
                    {
                        case "Today":
                            ScrapList.Add(scrap3);
                            ScrapList.Add(scrap4);
                            break;
                        case "Week":
                            ScrapList.Add(scrap3);
                            ScrapList.Add(scrap4);
                            ScrapList.Add(scrap2);
                            break;
                        case "Month":
                            ScrapList.Add(scrap3);
                            ScrapList.Add(scrap4);
                            ScrapList.Add(scrap2);
                            ScrapList.Add(scrap1);
                            break;
                    }
                    break;
            }
        }
        private void LoadOEEUpToDown(string plant, string period)
        {
            CellList = new ObservableCollection<Cell>();
            Cell cell1 = new Cell()
            {
                Id = "3",
                Name = AppResources.CellLabel + " 3",
                OEE = "91%",
                Status = "#00a889",
                Progress = new Xamarin.Forms.Rectangle(0,0,.91,5),
                Metrics = new Metrics()
                {
                    D = "90%",
                    V = "91%",
                    C = "89%"
                }
            };
            Cell cell2 = new Cell()
            {
                Id = "4",
                Name = AppResources.CellLabel + " 4",
                OEE = "88%",
                Status = "#00a889",
                Progress = new Xamarin.Forms.Rectangle(0, 0, .88, 5),
                Metrics = new Metrics()
                {
                    D = "88%",
                    V = "88%",
                    C = "88%"
                }
            };
            Cell cell3 = new Cell()
            {
                Id = "1",
                Name = AppResources.CellLabel + " 1",
                OEE = "83%",
                Status = "#d2434a",
                Progress = new Xamarin.Forms.Rectangle(0, 0, .83, 5),
                Metrics = new Metrics()
                {
                    D = "83%",
                    V = "80%",
                    C = "86%"
                }
            };
            Cell cell4 = new Cell()
            {
                Id = "2",
                Name = AppResources.CellLabel + " 2",
                OEE = "70%",
                Status = "#d2434a",
                Progress = new Xamarin.Forms.Rectangle(0, 0, .7, 5),
                Metrics = new Metrics()
                {
                    D = "83%",
                    V = "65%",
                    C = "76%"
                }
            };
            switch (plant)
            {
                case "M1":
                    switch (period)
                    {
                        case "Today":
                            CellList.Add(cell1);
                            CellList.Add(cell2);
                            CellList.Add(cell3);
                            CellList.Add(cell4);
                            break;
                        case "Week":
                            CellList.Add(cell2);
                            CellList.Add(cell4);
                            CellList.Add(cell3);
                            CellList.Add(cell1);
                            break;
                        case "Month":
                            CellList.Add(cell4);
                            CellList.Add(cell2);
                            CellList.Add(cell1);
                            CellList.Add(cell3);
                            break;
                    }
                    break;
                case "M2":
                    switch (period)
                    {
                        case "Today":
                            CellList.Add(cell3);
                            CellList.Add(cell2);
                            break;
                        case "Week":
                            CellList.Add(cell3);
                            CellList.Add(cell2);
                            CellList.Add(cell4);
                            break;
                        case "Month":
                            CellList.Add(cell3);
                            CellList.Add(cell2);
                            CellList.Add(cell4);
                            CellList.Add(cell1);
                            break;
                    }
                    break;
                case "M3":
                    switch (period)
                    {
                        case "Today":
                            CellList.Add(cell4);
                            CellList.Add(cell3);
                            break;
                        case "Week":
                            CellList.Add(cell4);
                            CellList.Add(cell3);
                            CellList.Add(cell1);
                            break;
                        case "Month":
                            CellList.Add(cell4);
                            CellList.Add(cell3);
                            CellList.Add(cell1);
                            CellList.Add(cell2);
                            break;
                    }
                    break;
            }
            HeightListViewOEE = (30 * CellList.Count) + 10;
            OrderOEE = "DESC";
            CmdOrder = new Command((param) =>
                OrderData(param.ToString()));
        }

        private void OrderData(string fieldOrder)
        {
            List<Cell> temp = new List<Cell>(CellList);
            ObservableCollection<Cell> tempCells = CellList;
            switch (fieldOrder)
            {
                case "Name":
                    if (OrderName == null)
                        OrderName = "ASC";

                    if (OrderName == "ASC")
                    {
                        temp.Sort((a, b) => a.Name.CompareTo(b.Name));
                        OrderName = "DESC";
                    }
                    else
                    {
                        temp.Sort((a, b) => b.Name.CompareTo(a.Name));
                        OrderName = "ASC";
                    }
                    break;
                case "Progress":
                    if (OrderProgress == null)
                        OrderProgress = "ASC";

                    if (OrderProgress == "ASC")
                    {
                        temp.Sort((a, b) => a.OEE.CompareTo(b.OEE));
                        OrderProgress = "DESC";
                    }
                    else
                    {
                        temp.Sort((a, b) => b.OEE.CompareTo(a.OEE));
                        OrderProgress = "ASC";
                    }
                    break;
                case "OEE":
                    if (OrderOEE == "ASC")
                    {
                        temp.Sort((a, b) => a.OEE.CompareTo(b.OEE));
                        OrderOEE = "DESC";
                    }
                    else
                    {
                        temp.Sort((a, b) => b.OEE.CompareTo(a.OEE));
                        OrderOEE = "ASC";
                    }
                    break;
                case "Metrics":
                    if (OrderMetrics == null)
                        OrderMetrics = "ASC";

                    if (OrderMetrics == "ASC")
                    {
                        temp.Sort((a, b) => a.Metrics.D.CompareTo(b.Metrics.D));
                        OrderMetrics = "DESC";
                    }
                    else
                    {
                        temp.Sort((a, b) => b.Metrics.D.CompareTo(a.Metrics.D));
                        OrderMetrics = "ASC";
                    }
                    break;
            }
            for (int i = 0; i < temp.Count; i++)
            {
                tempCells.Move(CellList.IndexOf(temp[i]), i);
            }
            CellList = tempCells;
        }

        private void LoadTickets(string plant, string period)
        {
            OpenTicketList = new ObservableCollection<Ticket>();
            InProcessTicketList = new ObservableCollection<Ticket>();
            ClosedTicketList = new ObservableCollection<Ticket>();
            CmdAssign = new Command((param) =>
                    AssignTicket(param.ToString()));
            CmdViewDetails = new Command((param) =>
                            ViewDetails(param.ToString()));
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
                IsSelected = false,
                TextButton = AppResources.AssignLabel,
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
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
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
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
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
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
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
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
                ButtonBorder = "#36A889",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            Ticket ticket7 = new Ticket()
            {
                Id = "7",
                Status = "Abierto",
                ImgStatus = "open.png",
                Description = AppResources.Maintenance,
                Hour = "10:15 AM",
                Machine = "M102",
                OEE = "93%",
                Cell = "C2",
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
                ButtonBorder = "#336EF4",
                CmdName = "CmdAssign",
                CmdButton = (Command)CmdAssign
            };
            Ticket ticket8 = new Ticket()
            {
                Id = "8",
                Status = "Abierto",
                ImgStatus = "open.png",
                Description = AppResources.LeakLabel,
                Hour = "10:24 AM",
                Machine = "M301",
                OEE = "99%",
                Cell = "C3",
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
                ButtonBorder = "#336EF4",
                CmdName = "CmdAssign",
                CmdButton = (Command)CmdAssign
            };
            Ticket ticket9 = new Ticket()
            {
                Id = "9",
                Status = "En Proceso",
                ImgStatus = "clock.png",
                Description = AppResources.MinorIncident,
                Hour = "11:47 AM",
                Machine = "M103",
                OEE = "86%",
                Cell = "C3",
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
                ButtonBorder = "#F88300",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            Ticket ticket10 = new Ticket()
            {
                Id = "10",
                Status = "Cerrado",
                ImgStatus = "done.png",
                Description = AppResources.LackMaterial,
                Hour = "08:33 AM",
                Machine = "M102",
                OEE = "95%",
                Cell = "C1",
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
                ButtonBorder = "#36A889",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            Ticket ticket11 = new Ticket()
            {
                Id = "11",
                Status = "Cerrado",
                ImgStatus = "done.png",
                Description = AppResources.LackMaterial,
                Hour = "03:49 PM",
                Machine = "M103",
                OEE = "88%",
                Cell = "C3",
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
                ButtonBorder = "#36A889",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            Ticket ticket12 = new Ticket()
            {
                Id = "12",
                Status = "Cerrado",
                ImgStatus = "done.png",
                Description = AppResources.LackMaterial,
                Hour = "06:18 PM",
                Machine = "M102",
                OEE = "90%",
                Cell = "C2",
                IsSelected = false,
                TextButton = AppResources.DetailsLabel,
                ButtonBorder = "#36A889",
                CmdName = "CmdViewDetails",
                CmdButton = (Command)CmdViewDetails
            };
            switch (plant)
            {
                case "M1":
                    switch (period)
                    {
                        case "Today":
                            OpenTicketList.Add(ticket1);
                            OpenTicketList.Add(ticket2);
                            InProcessTicketList.Add(ticket3);
                            InProcessTicketList.Add(ticket4);
                            ClosedTicketList.Add(ticket6);
                            break;
                        case "Week":
                            OpenTicketList.Add(ticket1);
                            OpenTicketList.Add(ticket2);
                            OpenTicketList.Add(ticket7);
                            InProcessTicketList.Add(ticket3);
                            InProcessTicketList.Add(ticket4);
                            InProcessTicketList.Add(ticket9);
                            ClosedTicketList.Add(ticket6);
                            ClosedTicketList.Add(ticket10);
                            break;
                        case "Month":
                            OpenTicketList.Add(ticket1);
                            OpenTicketList.Add(ticket2);
                            OpenTicketList.Add(ticket7);
                            OpenTicketList.Add(ticket8);
                            InProcessTicketList.Add(ticket3);
                            InProcessTicketList.Add(ticket4);
                            InProcessTicketList.Add(ticket9);
                            InProcessTicketList.Add(ticket5);
                            ClosedTicketList.Add(ticket6);
                            ClosedTicketList.Add(ticket10);
                            ClosedTicketList.Add(ticket11);
                            break;
                    }
                    break;
                case "M2":
                    switch (period)
                    {
                        case "Today":
                            OpenTicketList.Add(ticket7);
                            OpenTicketList.Add(ticket1);
                            InProcessTicketList.Add(ticket9);
                            InProcessTicketList.Add(ticket3);
                            ClosedTicketList.Add(ticket11);
                            break;
                        case "Week":
                            OpenTicketList.Add(ticket7);
                            OpenTicketList.Add(ticket1);
                            OpenTicketList.Add(ticket8);
                            InProcessTicketList.Add(ticket9);
                            InProcessTicketList.Add(ticket3);
                            InProcessTicketList.Add(ticket5);
                            ClosedTicketList.Add(ticket11);
                            ClosedTicketList.Add(ticket10);
                            break;
                        case "Month":
                            OpenTicketList.Add(ticket7);
                            OpenTicketList.Add(ticket1);
                            OpenTicketList.Add(ticket8);
                            OpenTicketList.Add(ticket2);
                            InProcessTicketList.Add(ticket9);
                            InProcessTicketList.Add(ticket3);
                            InProcessTicketList.Add(ticket5);
                            InProcessTicketList.Add(ticket4);
                            ClosedTicketList.Add(ticket11);
                            ClosedTicketList.Add(ticket10);
                            ClosedTicketList.Add(ticket6);
                            break;
                    }
                    break;
                case "M3":
                    switch (period)
                    {
                        case "Today":
                            OpenTicketList.Add(ticket8);
                            OpenTicketList.Add(ticket7);
                            InProcessTicketList.Add(ticket5);
                            InProcessTicketList.Add(ticket9);
                            ClosedTicketList.Add(ticket11);
                            break;
                        case "Week":
                            OpenTicketList.Add(ticket8);
                            OpenTicketList.Add(ticket7);
                            OpenTicketList.Add(ticket2);
                            InProcessTicketList.Add(ticket5);
                            InProcessTicketList.Add(ticket9);
                            InProcessTicketList.Add(ticket4);
                            ClosedTicketList.Add(ticket11);
                            ClosedTicketList.Add(ticket6);
                            break;
                        case "Month":
                            OpenTicketList.Add(ticket8);
                            OpenTicketList.Add(ticket7);
                            OpenTicketList.Add(ticket2);
                            OpenTicketList.Add(ticket1);
                            InProcessTicketList.Add(ticket5);
                            InProcessTicketList.Add(ticket9);
                            InProcessTicketList.Add(ticket4);
                            InProcessTicketList.Add(ticket3);
                            ClosedTicketList.Add(ticket11);
                            ClosedTicketList.Add(ticket6);
                            ClosedTicketList.Add(ticket10);
                            break;
                    }
                    break;
            }
            HeightListViewOpen = (65 * OpenTicketList.Count) + 10;
            HeightListViewInProcess = (65 * InProcessTicketList.Count) + 10;
            HeightListViewClosed = (65 * ClosedTicketList.Count) + 10;
        }

        private void LoadDropDown()
        {
            PlantList = new List<string>();
            PlantList.Add("M1");
            PlantList.Add("M2");
            PlantList.Add("M3");
            PlantSelected = "M1";
        }

        public async void ViewDetails(string ticketId)
        {
            string status = GetStatus(ticketId);
            await App.MasterDP.Detail.Navigation.PushAsync(new SupportDetail(ticketId, status));
        }

        public string GetStatus(string ticketId)
        {
            string status = string.Empty;
            foreach (Ticket t in InProcessTicketList)
            {
                if (t.Id == ticketId)
                {
                    return AppResources.InProcessLabel;
                }
            }
            foreach (Ticket t in ClosedTicketList)
            {
                if (t.Id == ticketId)
                {
                    return AppResources.ClosedLabel;
                }
            }
            return status;
        }

        public void AssignTicket(string ticketId)
        {
            Console.WriteLine(ticketId);
        }
    }
}
