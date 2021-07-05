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
using Flexbaze.ViewModels.Base;

namespace Flexbaze.ViewModels
{
    class DashboardViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public enum Planning
        {
            Today,
            Week,
            Month
        }
        private ObservableCollection<ChartEntry> _entryList;
        private ObservableCollection<ChartEntry> _entryScrapList;
        private ObservableCollection<Cell> _cellList;
        private ObservableCollection<Stoppage> _stopList;
        private ObservableCollection<Scrap> _scrapList;
        private ObservableCollection<TicketComplete> _openTicketList;
        private ObservableCollection<TicketComplete> _inProcessTicketList;
        private ObservableCollection<TicketComplete> _closedTicketList;
        private List<TicketComplete> _filterTicketList;
        private List<FactoryType> _plantList;
        private FactoryType _plantSelected;
        private double _heightListViewOEE;
        private double _heightListViewOpen;
        private double _heightListViewInProcess;
        private double _heightListViewClosed;
        private double _heightScrapChart;
        private double _heightScrapList;
        private double _heightEntryChart;
        private double _heightEntryList;
        private string _orderName;
        private string _orderProgress;
        private string _orderOEE;
        private string _orderMetrics;
        private string _bestTeamLeaderCell;
        private int _accidents;
        private int _incidents;
        private bool _showAccidents;
        public Command CmdOrder { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigationHandler NavigationHandler { private get; set; }

        public ObservableCollection<ChartEntry> EntryList
        {
            get => _entryList;
            private set
            {
                _entryList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ChartEntry> EntryScrapList
        {
            get => _entryScrapList;
            private set
            {
                _entryScrapList = value;
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

        public ObservableCollection<TicketComplete> OpenTicketList
        {
            get => _openTicketList;
            private set
            {
                _openTicketList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TicketComplete> InProcessTicketList
        {
            get => _inProcessTicketList;
            private set
            {
                _inProcessTicketList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TicketComplete> ClosedTicketList
        {
            get => _closedTicketList;
            private set
            {
                _closedTicketList = value;
                OnPropertyChanged();
            }
        }

        public List<FactoryType> PlantList
        {
            get => _plantList;
            private set
            {
                _plantList = value;
                OnPropertyChanged();
            }
        }

        public List<TicketComplete> FilterTicketList
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

        public double HeightScrapChart
        {
            get => _heightScrapChart;
            private set
            {
                _heightScrapChart = value;
                OnPropertyChanged();
            }
        }

        public double HeightScrapList
        {
            get => _heightScrapList;
            private set
            {
                _heightScrapList = value;
                OnPropertyChanged();
            }
        }

        public double HeightEntryChart
        {
            get => _heightEntryChart;
            private set
            {
                _heightEntryChart = value;
                OnPropertyChanged();
            }
        }

        public double HeightEntryList
        {
            get => _heightEntryList;
            private set
            {
                _heightEntryList = value;
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

        public FactoryType PlantSelected
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

        public string BestTeamLeaderCell
        {
            get => _bestTeamLeaderCell;
            private set
            {
                _bestTeamLeaderCell = value;
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

        public DashboardViewModel(INavigationHandler _NavigationHandler) : base()
        {
            NavigationHandler = _NavigationHandler;
            Ini();
        }

        private void Ini()
        {
            showIndicator();
            LoadEntries(Planning.Today);
            LoadScrap(Planning.Today);
            LoadOEEUpToDown();
            LoadTickets();
            LoadDropDown();
            Accidents = 0;
            Incidents = 0;
            if (Accidents == 0 && Incidents == 0)
                ShowAccidents = false;
            else
                ShowAccidents = true;
            closeIndicator();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void LoadEntries(Planning planning)
        {
            EntryList = new ObservableCollection<ChartEntry>();
            StopList = new ObservableCollection<Stoppage>();
            StopsStats stops = GetStops();
            List<StopsCountStats> stopsCountStats = new List<StopsCountStats>();
            switch (planning)
            {
                case Planning.Today:
                    stopsCountStats = stops.Today;
                    break;
                case Planning.Week:
                    stopsCountStats = stops.Week;
                    break;
                case Planning.Month:
                    stopsCountStats = stops.Month;
                    break;
            }
            int qtyTotal = 0;

            for (int i = 0; i < stopsCountStats.Count; i++)
            {
                Stoppage stop1 = new Stoppage() { Name = stopsCountStats[i].Description };
                qtyTotal += stopsCountStats[i].Count;
                switch (i)
                {
                    case 0:
                        stop1.ColorLabel = Color.FromHex("#2BB9f1");
                        break;
                    case 1:
                        stop1.ColorLabel = Color.FromHex("#A509D0");
                        break;
                    case 2:
                        stop1.ColorLabel = Color.FromHex("#E26716");
                        break;
                    case 3:
                        stop1.ColorLabel = Color.FromHex("#5228EA");
                        break;
                    case 4:
                        stop1.ColorLabel = Color.FromHex("#71BD4E");
                        break;
                }
                StopList.Add(stop1);
            }

            for (int j = 0; j < StopList.Count; j++)
            {
                if (qtyTotal > 0)
                {
                    StopList[j].Percentage = (stopsCountStats[j].Count * 100 / qtyTotal).ToString();
                }

                ChartEntry ent1 = new ChartEntry(float.Parse(StopList[j].Percentage ?? "0"))
                {
                    Color = SKColor.Parse(StopList[j].ColorLabel.ToHex()),
                    TextColor = SKColor.Parse("#FFFFFF"),
                    ValueLabelColor = SKColor.Parse("#FFFFFF"),
                    Label = " ",
                    ValueLabel = (StopList[j].Percentage ?? "0") + "%"
                };
                EntryList.Add(ent1);
            }

            HeightEntryChart = EntryList.Count * 50;
            HeightEntryList = StopList.Count > 2 ? (StopList.Count * 55) : StopList.Count > 0 ? 160 : 0;
        }

        private StopsStats GetStops()
        {
            StopsStats ss = new StopsStats();
            ss.Today = new List<StopsCountStats>()
            {
                new StopsCountStats()
                {
                    Count = 2,
                    Description = AppResources.SamplingLabel
                },
                new StopsCountStats()
                {
                    Count = 4,
                    Description = "Setup CM"
                },
                new StopsCountStats()
                {
                    Count = 3,
                    Description = AppResources.LackMold
                },
                new StopsCountStats()
                {
                    Count = 1,
                    Description = AppResources.MoldRoutine
                },
                new StopsCountStats()
                {
                    Count = 4,
                    Description = AppResources.PackedLabel
                },
            };
            ss.Week = new List<StopsCountStats>()
            {
                new StopsCountStats()
                {
                    Count = 4,
                    Description = AppResources.SamplingLabel
                },
                new StopsCountStats()
                {
                    Count = 6,
                    Description = "Setup CM"
                },
                new StopsCountStats()
                {
                    Count = 5,
                    Description = AppResources.LackMold
                },
                new StopsCountStats()
                {
                    Count = 3,
                    Description = AppResources.MoldRoutine
                },
                new StopsCountStats()
                {
                    Count = 6,
                    Description = AppResources.PackedLabel
                },
            };
            ss.Month = new List<StopsCountStats>()
            {
                new StopsCountStats()
                {
                    Count = 7,
                    Description = AppResources.SamplingLabel
                },
                new StopsCountStats()
                {
                    Count = 10,
                    Description = "Setup CM"
                },
                new StopsCountStats()
                {
                    Count = 8,
                    Description = AppResources.LackMold
                },
                new StopsCountStats()
                {
                    Count = 6,
                    Description = AppResources.MoldRoutine
                },
                new StopsCountStats()
                {
                    Count = 11,
                    Description = AppResources.PackedLabel
                },
            };
            return ss;
        }

        public void LoadScrap(Planning planning)
        {
            EntryScrapList = new ObservableCollection<ChartEntry>();
            ScrapList = new ObservableCollection<Scrap>();
            int qtyTotal = 0;
            ScrapStats scraps = GetScraps();

            List<ScrapCountStats> scrapCountStats = new List<ScrapCountStats>();
            switch (planning)
            {
                case Planning.Today:
                    scrapCountStats = scraps.Today;
                    break;
                case Planning.Week:
                    scrapCountStats = scraps.Week;
                    break;
                case Planning.Month:
                    scrapCountStats = scraps.Month;
                    break;
            }

            for (int i = 0; i < scrapCountStats.Count; i++)
            {
                if (i < 5)
                {
                    Scrap scrap1 = new Scrap() { Name = scrapCountStats[i].Description };
                    qtyTotal += scrapCountStats[i].Count;
                    switch (i)
                    {
                        case 0:
                            scrap1.ColorLabel = Color.FromHex("#2BB9F1");
                            break;
                        case 1:
                            scrap1.ColorLabel = Color.FromHex("#A509D0");
                            break;
                        case 2:
                            scrap1.ColorLabel = Color.FromHex("#E26716");
                            break;
                        case 3:
                            scrap1.ColorLabel = Color.FromHex("#5228EA");
                            break;
                        case 4:
                            scrap1.ColorLabel = Color.FromHex("#71BD4E");
                            break;
                    }
                    ScrapList.Add(scrap1);
                }
            }

            for (int j = 0; j < ScrapList.Count; j++)
            {
                if (qtyTotal > 0)
                {
                    ScrapList[j].Percentage = (scrapCountStats[j].Count * 100 / qtyTotal).ToString();
                }

                ChartEntry ent2 = new ChartEntry(float.Parse(ScrapList[j].Percentage ?? "0"))
                {
                    Color = SKColor.Parse(ScrapList[j].ColorLabel.ToHex()),
                    TextColor = SKColor.Parse("#FFFFFF"),
                    ValueLabelColor = SKColor.Parse("#FFFFFF"),
                    Label = " ",
                    ValueLabel = (ScrapList[j].Percentage ?? "0") + "%"
                };
                EntryScrapList.Add(ent2);
            }

            HeightScrapChart = EntryScrapList.Count * 50;
            HeightScrapList = ScrapList.Count > 2 ? (ScrapList.Count * 55) : ScrapList.Count > 0 ? 160 : 0;
        }

        private ScrapStats GetScraps()
        {
            ScrapStats ss = new ScrapStats();
            ss.Today = new List<ScrapCountStats>()
            {
                new ScrapCountStats()
                {
                    Count = 2,
                    Description = AppResources.CauseLabel + " 1"
                },
                new ScrapCountStats()
                {
                    Count = 4,
                    Description = AppResources.CauseLabel + " 2"
                },
                new ScrapCountStats()
                {
                    Count = 3,
                    Description = AppResources.CauseLabel + " 3"
                },
                new ScrapCountStats()
                {
                    Count = 1,
                    Description = AppResources.CauseLabel + " 4"
                },
                new ScrapCountStats()
                {
                    Count = 4,
                    Description = AppResources.CauseLabel + " 5"
                },
            };
            ss.Week = new List<ScrapCountStats>()
            {
                new ScrapCountStats()
                {
                    Count = 4,
                    Description = AppResources.CauseLabel + " 1"
                },
                new ScrapCountStats()
                {
                    Count = 6,
                    Description = AppResources.CauseLabel + " 2"
                },
                new ScrapCountStats()
                {
                    Count = 5,
                    Description = AppResources.CauseLabel + " 3"
                },
                new ScrapCountStats()
                {
                    Count = 3,
                    Description = AppResources.CauseLabel + " 4"
                },
                new ScrapCountStats()
                {
                    Count = 6,
                    Description = AppResources.CauseLabel + " 5"
                },
            };
            ss.Month = new List<ScrapCountStats>()
            {
                new ScrapCountStats()
                {
                    Count = 7,
                    Description = AppResources.CauseLabel + " 1"
                },
                new ScrapCountStats()
                {
                    Count = 10,
                    Description = AppResources.CauseLabel + " 2"
                },
                new ScrapCountStats()
                {
                    Count = 8,
                    Description = AppResources.CauseLabel + " 3"
                },
                new ScrapCountStats()
                {
                    Count = 6,
                    Description = AppResources.CauseLabel + " 4"
                },
                new ScrapCountStats()
                {
                    Count = 11,
                    Description = AppResources.CauseLabel + " 5"
                },
            };
            return ss;
        }

        private void LoadOEEUpToDown()
        {
            CellList = new ObservableCollection<Cell>();
            Cell cell1 = new Cell()
            {
                Id = "3",
                Name = "Celda 3",
                OEE = "91%",
                Status = "#00a889",
                Progress = new Xamarin.Forms.Rectangle(0, 0, .91, 5),
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
                Name = "Celda 4",
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
                Name = "Celda 1",
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
                Name = "Celda 2",
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
            CellList.Add(cell1);
            CellList.Add(cell2);
            CellList.Add(cell3);
            CellList.Add(cell4);
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

        private void LoadTickets()
        {
            OpenTicketList = new ObservableCollection<TicketComplete>();
            InProcessTicketList = new ObservableCollection<TicketComplete>();
            ClosedTicketList = new ObservableCollection<TicketComplete>();
            TicketComplete ticket1 = new TicketComplete()
            {
                Id = "1",
                Cell = new CellType()
                {
                    Id = "1",
                    Name = "C1"
                },
                Machine = new MachineType()
                {
                    Id = "1",
                    Name = "TRO-011"
                },
                StartedAt = new DateTime(2020, 05, 22, 10, 12, 19),
                EndedAtCommitment = new DateTime(),
                EndedAt = new DateTime(),
                Status = AppResources.OpenLabel,
                ReportedBy = new UserType()
                {
                    Id = "4",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Juan",
                    LastName = "Perez",
                    Profile = new ProfileType()
                    {
                        Id = "3",
                        Name = "Juan Perez",
                        Picture = ""
                    },
                },
                Description = AppResources.LackMaterial,
                ImgStatus = "open.png",
                Hour = "10:12 AM",
                TextButton = AppResources.AssignLabel,
                Progress = new Rectangle(19, 30, 2, 40),
                IsSelected = false,
                ButtonBorder = "#336EF4",
                CmdName = "CmdAssign",
                CmdAssign = new Command((param) =>
                            AssignTicket((TicketComplete)param))
            };
            TicketComplete ticket2 = new TicketComplete()
            {
                Id = "2",
                Status = AppResources.OpenLabel,
                ImgStatus = "open.png",
                Description = AppResources.LackMaterial,
                Hour = "10:16 PM",
                Machine = new MachineType()
                {
                    Id = "2",
                    Name = "CORT-007"
                },
                Cell = new CellType()
                {
                    Id = "1",
                    Name = "C1"
                },
                StartedAt = new DateTime(2020, 05, 22, 22, 16, 19),
                EndedAtCommitment = new DateTime(),
                EndedAt = new DateTime(),
                ReportedBy = new UserType()
                {
                    Id = "4",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Juan",
                    LastName = "Perez",
                    Profile = new ProfileType()
                    {
                        Id = "3",
                        Name = "Juan Perez",
                        Picture = ""
                    },
                },
                TextButton = AppResources.AssignLabel,
                Progress = new Rectangle(19, 0, 2, 35),
                IsSelected = false,
                ButtonBorder = "#336EF4",
                CmdName = "CmdAssign",
                CmdAssign = new Command((param) =>
                            AssignTicket((TicketComplete)param))
            };
            TicketComplete ticket3 = new TicketComplete()
            {
                Id = "3",
                Status = AppResources.InProcessLabel,
                ImgStatus = "clock.png",
                Description = AppResources.LackMaterial,
                Hour = "07:25 AM",
                Machine = new MachineType()
                {
                    Id = "1",
                    Name = "ROLA-003"
                },
                Cell = new CellType()
                {
                    Id = "1",
                    Name = "C1"
                },
                StartedAt = new DateTime(2020, 05, 22, 07, 25, 19),
                EndedAtCommitment = new DateTime(),
                EndedAt = new DateTime(),
                ReportedBy = new UserType()
                {
                    Id = "4",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Juan",
                    LastName = "Perez",
                    Profile = new ProfileType()
                    {
                        Id = "3",
                        Name = "Juan Perez",
                        Picture = ""
                    },
                },
                AssignedTo = new UserType()
                {
                    Id = "2",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Ricardo",
                    LastName = "García",
                    Profile = new ProfileType()
                    {
                        Id = "2",
                        Name = "Ricardo García",
                        Picture = "https://flexbaze-demo.s3.amazonaws.com/pp.jpeg"
                    },
                },
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 30, 2, 40),
                IsSelected = false,
                ButtonBorder = "#F88300",
                CmdName = "CmdViewDetails",
                CmdViewDetails = new Command((param) =>
                            ViewDetails((TicketComplete)param))
            };
            TicketComplete ticket4 = new TicketComplete()
            {
                Id = "4",
                Status = AppResources.InProcessLabel,
                ImgStatus = "clock.png",
                Description = AppResources.LackMaterial,
                Hour = "03:33 PM",
                StartedAt = new DateTime(2020, 05, 22, 15, 33, 19),
                EndedAtCommitment = new DateTime(),
                EndedAt = new DateTime(),
                Machine = new MachineType()
                {
                    Id = "2",
                    Name = "PREN-015"
                },
                Cell = new CellType()
                {
                    Id = "1",
                    Name = "C1"
                },
                ReportedBy = new UserType()
                {
                    Id = "4",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Roberto",
                    LastName = "Lee",
                    Profile = new ProfileType()
                    {
                        Id = "3",
                        Name = "Roberto Lee",
                        Picture = ""
                    },
                },
                AssignedTo = new UserType()
                {
                    Id = "2",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Luis",
                    LastName = "García",
                    Profile = new ProfileType()
                    {
                        Id = "2",
                        Name = "Luis García",
                        Picture = "https://flexbaze-demo.s3.amazonaws.com/pp.jpeg"
                    },
                },
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 0, 2, 70),
                IsSelected = false,
                ButtonBorder = "#F88300",
                CmdName = "CmdViewDetails",
                CmdViewDetails = new Command((param) =>
                            ViewDetails((TicketComplete)param))
            };
            TicketComplete ticket5 = new TicketComplete()
            {
                Id = "5",
                Status = AppResources.InProcessLabel,
                ImgStatus = "clock.png",
                Description = AppResources.LackMaterial,
                Hour = "11:45 PM",
                StartedAt = new DateTime(2020, 05, 22, 23, 45, 19),
                EndedAtCommitment = new DateTime(),
                EndedAt = new DateTime(),
                Machine = new MachineType()
                {
                    Id = "1",
                    Name = "CIZ-021"
                },
                Cell = new CellType()
                {
                    Id = "1",
                    Name = "C1"
                },
                ReportedBy = new UserType()
                {
                    Id = "4",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Dante",
                    LastName = "Juárez",
                    Profile = new ProfileType()
                    {
                        Id = "3",
                        Name = "Dante Juárez",
                        Picture = ""
                    },
                },
                AssignedTo = new UserType()
                {
                    Id = "2",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Luis",
                    LastName = "García",
                    Profile = new ProfileType()
                    {
                        Id = "2",
                        Name = "Luis García",
                        Picture = "https://flexbaze-demo.s3.amazonaws.com/pp.jpeg"
                    },
                },
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 0, 2, 35),
                IsSelected = false,
                ButtonBorder = "#F88300",
                CmdName = "CmdViewDetails",
                CmdViewDetails = new Command((param) =>
                            ViewDetails((TicketComplete)param))
            };
            TicketComplete ticket6 = new TicketComplete()
            {
                Id = "6",
                Status = AppResources.ClosedLabel,
                ImgStatus = "done.png",
                Description = AppResources.LackMaterial,
                Hour = "11:11 AM",
                Machine = new MachineType()
                {
                    Id = "1",
                    Name = "PUNZ-008"
                },
                Cell = new CellType()
                {
                    Id = "1",
                    Name = "C1"
                },
                StartedAt = new DateTime(2020, 05, 22, 11, 11, 19),
                EndedAtCommitment = new DateTime(),
                EndedAt = new DateTime(),
                ReportedBy = new UserType()
                {
                    Id = "4",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "Dante",
                    LastName = "Juárez",
                    Profile = new ProfileType()
                    {
                        Id = "3",
                        Name = "Dante Juárez",
                        Picture = ""
                    },
                },
                AssignedTo = new UserType()
                {
                    Id = "2",
                    Groups = new List<GroupType>()
                    {
                      new GroupType()
                      {
                          Id = "4",
                            Name = "technician"
                      }
                    },
                    FirstName = "José",
                    LastName = "Loera",
                    Profile = new ProfileType()
                    {
                        Id = "2",
                        Name = "Jose Loera",
                        Picture = "https://flexbaze-demo.s3.amazonaws.com/pp.jpeg"
                    },
                },
                Events = new List<TicketEventType>()
                {
                    new TicketEventType()
                    {
                        Id = "14",
                        Description = "Hola",
                        Timestamp = new DateTime(2021,05,24,16,45,03),
                        EventType = "Detail",
                        User = new UserType()
                        {
                            Profile = new ProfileType()
                            {
                                Picture = "",
                                Name = ""
                            }
                        }
                    },
                    new TicketEventType()
                    {
                        Id = "15",
                        Description = "H",
                        Timestamp = new DateTime(2021,05,26,19,55,43),
                        EventType = "Detail",
                        User = new UserType()
                        {
                            Profile = new ProfileType()
                            {
                                Picture = "",
                                Name = ""
                            }
                        }
                    },
                    new TicketEventType()
                    {
                        Id = "16",
                        Description = "Hola",
                        Timestamp = new DateTime(2021,06,09,16,46,02),
                        EventType = "Detail",
                        User = new UserType()
                        {
                            Profile = new ProfileType()
                            {
                                Picture = "",
                                Name = ""
                            }
                        }
                    },
                    new TicketEventType()
                    {
                        Id = "17",
                        Description = "Ticket cerrado",
                        Timestamp = new DateTime(2021,06,09,16,46,18),
                        EventType = null,
                        User = null
                    }
                },
                TextButton = AppResources.DetailsLabel,
                Progress = new Rectangle(19, 30, 0, 0),
                IsSelected = false,
                ButtonBorder = "#36A889",
                CmdName = "CmdViewDetails",
                CmdViewDetails = new Command((param) =>
                            ViewDetails((TicketComplete)param))
            };
            OpenTicketList.Add(ticket1);
            OpenTicketList.Add(ticket2);
            InProcessTicketList.Add(ticket3);
            InProcessTicketList.Add(ticket4);
            InProcessTicketList.Add(ticket5);
            ClosedTicketList.Add(ticket6);
            HeightListViewOpen = (65 * OpenTicketList.Count) + 10;
            HeightListViewInProcess = (65 * InProcessTicketList.Count) + 10;
            HeightListViewClosed = (65 * ClosedTicketList.Count) + 10;
        }

        private void LoadDropDown()
        {
            PlantList = new List<FactoryType>();
            PlantList.Add(new FactoryType() { Id = "1", Name = "M1" });
            PlantList.Add(new FactoryType() { Id = "1", Name = "M2" });
            PlantList.Add(new FactoryType() { Id = "1", Name = "M3" });
            PlantSelected = PlantList[0];
        }

        public void ViewDetails(TicketComplete ticket)
        {
            if (ticket != null)
            {
                NavigationHandler.ViewDetailsTicketAsync(ticket, PlantSelected.Id);
            }
        }
        public void AssignTicket(TicketComplete ticket)
        {
            if (ticket != null)
            {
                NavigationHandler.AssignTicketAsync(ticket.Id, ticket.Status);
            }
        }

        public interface INavigationHandler
        {
            void AssignTicketAsync(string ticketId, string status);
            void ViewDetailsTicketAsync(TicketComplete ticket, string factory);
        }
    }
}