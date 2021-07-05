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
using Flexbaze.ViewModels.Base;

namespace Flexbaze.ViewModels
{
    class ChronologyViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Request _request = new Request();
        private ObservableCollection<TicketComplete> _openTicketList;
        private ObservableCollection<TicketComplete> _inProcessTicketList;
        private ObservableCollection<TicketComplete> _closedTicketList;
        private ObservableCollection<TicketComplete> _filterTicketList;
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
        private TicketComplete _openSelectedItem;
        private List<FactoryType> _plantList;
        private List<FactoryType> _familyMachineList;
        private FactoryType _plantSelected;
        private FactoryType _familyMachineSelected;
        public Command CmdTickets { get; set; }
        public Command CmdSelected { get; set; }
        public ICommand CmdAssign { get; set; }
        public ICommand CmdViewDetails { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigationHandler NavigationHandler { private get; set; }
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

        public TicketComplete OpenSelectedItem
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

        public List<FactoryType> PlantList
        {
            get => _plantList;
            private set
            {
                _plantList = value;
                OnPropertyChanged();
            }
        }

        public List<FactoryType> FamilyMachineList
        {
            get => _familyMachineList;
            private set
            {
                _familyMachineList = value;
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

        public FactoryType FamilyMachineSelected
        {
            get => _familyMachineSelected;
            private set
            {
                _familyMachineSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TicketComplete> FilterTicketList
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

        public ChronologyViewModel(INavigationHandler _NavigationHandler) : base()
        {
            NavigationHandler = _NavigationHandler;
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
            PlantList = new List<FactoryType>();
            FamilyMachineList = new List<FactoryType>();
            CmdSelected = new Command((param) =>
                    SelectedTicket((TicketComplete)param));
            OpenTicketList = new ObservableCollection<TicketComplete>();
            InProcessTicketList = new ObservableCollection<TicketComplete>();
            ClosedTicketList = new ObservableCollection<TicketComplete>();
            FilterTicketList = new ObservableCollection<TicketComplete>();
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
            PlantList.Add(new FactoryType() { Id = "1", Name = "M1" });
            PlantList.Add(new FactoryType() { Id = "2", Name = "M2" });
            PlantList.Add(new FactoryType() { Id = "3", Name = "M3" });
            PlantSelected = PlantList[0];
            FamilyMachineList = new List<FactoryType>();
            FamilyMachineList.Add(new FactoryType() { Id = "1", Name = "General" });
            FamilyMachineList.Add(new FactoryType() { Id = "2", Name = "Roladora de Lámina" });
            FamilyMachineList.Add(new FactoryType() { Id = "3", Name = "Cortadora de Rollo" });
            FamilyMachineList.Add(new FactoryType() { Id = "4", Name = "Troqueladoras" });
            FamilyMachineList.Add(new FactoryType() { Id = "5", Name = "Prensas Cortina" });
            FamilyMachineList.Add(new FactoryType() { Id = "6", Name = "Presas Cortina CNC" });
            FamilyMachineList.Add(new FactoryType() { Id = "7", Name = "Punzonadoras" });
            FamilyMachineList.Add(new FactoryType() { Id = "8", Name = "Cizallas" });
            FamilyMachineList.Add(new FactoryType() { Id = "9", Name = "Tren Laminado" });
            FamilyMachineSelected = FamilyMachineList[0];
            Period = "Hoy";
        }

        public void SelectedTicket(TicketComplete t)
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

        public interface INavigationHandler
        {
            void AssignTicketAsync(string ticketId, string status);
            void ViewDetailsTicketAsync(TicketComplete ticket, string factory);
        }
    }
}