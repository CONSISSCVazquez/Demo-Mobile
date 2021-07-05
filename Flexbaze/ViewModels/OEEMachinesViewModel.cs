using Flexbaze.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Flexbaze.ViewModels
{
    class OEEMachinesViewModel : INotifyPropertyChanged
    {
        private Request _request = new Request();
        private ObservableCollection<OEEMachine> _allOEEMachineList;
        private ObservableCollection<OEEMachine> _filterOEEMachineList;
        private List<FactoryType> _sortList;
        private FactoryType _sortSelected;
        private List<FactoryType> _familyMachineList;
        private FactoryType _familyMachineSelected;
        private double _heightListViewOEE;
        private int _qtyInProduction;
        private int _qtyWithoutProducing;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<OEEMachine> AllOEEMachineList
        {
            get => _allOEEMachineList;
            private set
            {
                _allOEEMachineList = value;
                OnPropertyChanged();
            }
        }

        public List<FactoryType> SortList
        {
            get => _sortList;
            private set
            {
                _sortList = value;
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

        public ObservableCollection<OEEMachine> FilterOEEMachineList
        {
            get => _filterOEEMachineList;
            private set
            {
                _filterOEEMachineList = value;
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

        public FactoryType SortSelected
        {
            get => _sortSelected;
            private set
            {
                _sortSelected = value;
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

        public int QtyInProduction
        {
            get => _qtyInProduction;
            private set
            {
                _qtyInProduction = value;
                OnPropertyChanged();
            }
        }

        public int QtyWithoutProducing
        {
            get => _qtyWithoutProducing;
            private set
            {
                _qtyWithoutProducing = value;
                OnPropertyChanged();
            }
        }

        public OEEMachinesViewModel()
        {
            Ini();
        }

        private void Ini()
        {
            LoadOEEMachines();
            LoadDropDown();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void LoadOEEMachines()
        {
            AllOEEMachineList = new ObservableCollection<OEEMachine>();
            FilterOEEMachineList = new ObservableCollection<OEEMachine>();
            OEEMachine oee1 = new OEEMachine()
            {
                Id = "1",
                Status = "1",
                Hour = "",
                MachineName = "PREN-010",
                OEE = "96%",
                MachineFamily = "Prensas Cortina",
                Time = "98%",
                Speed = "93%",
                Quality = "97%"
            };
            OEEMachine oee2 = new OEEMachine()
            {
                Id = "2",
                Status = "1",
                Hour = "",
                MachineName = "PREN-015",
                OEE = "93%",
                MachineFamily = "Prensas Cortina CNC",
                Time = "92%",
                Speed = "93%",
                Quality = "94%"
            };
            OEEMachine oee3 = new OEEMachine()
            {
                Id = "3",
                Status = "1",
                Hour = "",
                MachineName = "ROLA-003",
                OEE = "90%",
                MachineFamily = "Roladora de Lámina",
                Time = "92%",
                Speed = "88%",
                Quality = "90%"
            };
            OEEMachine oee4 = new OEEMachine()
            {
                Id = "4",
                Status = "1",
                Hour = "",
                MachineName = "CORT-007",
                OEE = "88%",
                MachineFamily = "Cortadora de Rollo",
                Time = "90%",
                Speed = "88%",
                Quality = "92%"
            };
            OEEMachine oee5 = new OEEMachine()
            {
                Id = "5",
                Status = "1",
                Hour = "",
                MachineName = "TRO-011",
                OEE = "86%",
                MachineFamily = "Troqueladoras",
                Time = "90%",
                Speed = "80%",
                Quality = "90%"
            };
            OEEMachine oee6 = new OEEMachine()
            {
                Id = "6",
                Status = "0",
                Hour = "1 hr",
                MachineName = "TRO-003",
                OEE = "81%",
                MachineFamily = "Troqueladoras",
                Time = "85%",
                Speed = "78%",
                Quality = "80%"
            };
            OEEMachine oee7 = new OEEMachine()
            {
                Id = "7",
                Status = "0",
                Hour = "3 hr",
                MachineName = "PUNZ-008",
                OEE = "80%",
                MachineFamily = "Punzonadoras",
                Time = "82%",
                Speed = "78%",
                Quality = "80%"
            };
            OEEMachine oee8 = new OEEMachine()
            {
                Id = "8",
                Status = "0",
                Hour = "4 hr",
                MachineName = "CIZ-021",
                OEE = "79%",
                MachineFamily = "Cizallas",
                Time = "82%",
                Speed = "78%",
                Quality = "77%"
            };
            OEEMachine oee9 = new OEEMachine()
            {
                Id = "9",
                Status = "0",
                Hour = "5 hr",
                MachineName = "TREN-007",
                OEE = "78%",
                MachineFamily = "Tren Laminado",
                Time = "78%",
                Speed = "77%",
                Quality = "79%"
            };
            AllOEEMachineList.Add(oee1);
            AllOEEMachineList.Add(oee2);
            AllOEEMachineList.Add(oee3);
            AllOEEMachineList.Add(oee4);
            AllOEEMachineList.Add(oee5);
            AllOEEMachineList.Add(oee6);
            AllOEEMachineList.Add(oee7);
            AllOEEMachineList.Add(oee8);
            AllOEEMachineList.Add(oee9);
            FilterOEEMachineList.Add(oee1);
            FilterOEEMachineList.Add(oee2);
            FilterOEEMachineList.Add(oee3);
            FilterOEEMachineList.Add(oee4);
            FilterOEEMachineList.Add(oee5);
            FilterOEEMachineList.Add(oee6);
            FilterOEEMachineList.Add(oee7);
            FilterOEEMachineList.Add(oee8);
            FilterOEEMachineList.Add(oee9);
            QtyInProduction = 5;
            QtyWithoutProducing = 4;
            HeightListViewOEE = (65 * FilterOEEMachineList.Count) + 10;
        }

        private void LoadDropDown()
        {
            SortList = new List<FactoryType>();
            SortList.Add(new FactoryType() { Id = "1", Name = "Todos" });
            SortList.Add(new FactoryType() { Id = "2", Name = "OEE Alto" });
            SortList.Add(new FactoryType() { Id = "3", Name = "OEE Bajo" });
            SortSelected = SortList[0];

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
        }

        public void FilterOEEMachines(string sort, string family)
        {
            ObservableCollection<OEEMachine> auxList = new ObservableCollection<OEEMachine>();
            switch (sort)
            {
                case "Todos":
                    if (family == "General")
                    {
                        FilterOEEMachineList.Clear();
                        foreach (OEEMachine machine in AllOEEMachineList)
                        {
                            FilterOEEMachineList.Add(machine);
                            QtyInProduction = 5;
                            QtyWithoutProducing = 4;
                        }
                    }
                    else
                    {
                        foreach (OEEMachine machine in AllOEEMachineList)
                        {
                            if (machine.MachineFamily == family)
                                auxList.Add(machine);
                        }
                        FilterOEEMachineList.Clear();
                        QtyInProduction = 0;
                        QtyWithoutProducing = 0;
                        foreach (OEEMachine machine in auxList)
                        {
                            FilterOEEMachineList.Add(machine);
                            if (machine.Status == "0")
                                QtyWithoutProducing += 1;
                            else
                                QtyInProduction += 1;
                        }
                    }
                    break;
                case "OEE Alto":
                    if (family == "General")
                    {
                        foreach (OEEMachine machine in AllOEEMachineList)
                        {
                            if (double.Parse(machine.OEE.Substring(0, machine.OEE.Length - 1)) >= 85)
                                auxList.Add(machine);
                        }
                        FilterOEEMachineList.Clear();
                        QtyInProduction = 0;
                        QtyWithoutProducing = 0;
                        foreach (OEEMachine machine in auxList)
                        {
                            FilterOEEMachineList.Add(machine);
                            if (machine.Status == "0")
                                QtyWithoutProducing += 1;
                            else
                                QtyInProduction += 1;
                        }
                    }
                    else
                    {
                        foreach (OEEMachine machine in AllOEEMachineList)
                        {
                            if (machine.MachineFamily == family &&
                                double.Parse(machine.OEE.Substring(0, machine.OEE.Length - 1)) >= 85)
                                auxList.Add(machine);
                        }
                        FilterOEEMachineList.Clear();
                        QtyInProduction = 0;
                        QtyWithoutProducing = 0;
                        foreach (OEEMachine machine in auxList)
                        {
                            FilterOEEMachineList.Add(machine);
                            if (machine.Status == "0")
                                QtyWithoutProducing += 1;
                            else
                                QtyInProduction += 1;
                        }
                    }
                    break;
                case "OEE Bajo":
                    if (family == "General")
                    {
                        foreach (OEEMachine machine in AllOEEMachineList)
                        {
                            if (double.Parse(machine.OEE.Substring(0, machine.OEE.Length - 1)) < 85)
                                auxList.Add(machine);
                        }
                        FilterOEEMachineList.Clear();
                        QtyInProduction = 0;
                        QtyWithoutProducing = 0;
                        foreach (OEEMachine machine in auxList)
                        {
                            FilterOEEMachineList.Add(machine);
                            if (machine.Status == "0")
                                QtyWithoutProducing += 1;
                            else
                                QtyInProduction += 1;
                        }
                    }
                    else
                    {
                        foreach (OEEMachine machine in AllOEEMachineList)
                        {
                            if (machine.MachineFamily == family &&
                                double.Parse(machine.OEE.Substring(0, machine.OEE.Length - 1)) < 85)
                                auxList.Add(machine);
                        }
                        FilterOEEMachineList.Clear();
                        QtyInProduction = 0;
                        QtyWithoutProducing = 0;
                        foreach (OEEMachine machine in auxList)
                        {
                            FilterOEEMachineList.Add(machine);
                            if (machine.Status == "0")
                                QtyWithoutProducing += 1;
                            else
                                QtyInProduction += 1;
                        }
                    }
                    break;
            }
        }

        public void searchMachine(string search, string sort, string family)
        {
            List<OEEMachine> aux = new List<OEEMachine>();

            foreach (OEEMachine machine in FilterOEEMachineList)
            {
                aux.Add(machine);
            }

            FilterOEEMachineList.Clear();

            List<OEEMachine> machines_search = new List<OEEMachine>();
            if (search.Length > 0)
            {
                machines_search = aux.FindAll(x => (x.MachineName + " " + x.MachineFamily).ToLower().Contains(search.ToLower()));
            }
            else
            {
                FilterOEEMachines(sort, family);
                return;
            }

            QtyInProduction = 0;
            QtyWithoutProducing = 0;
            foreach (OEEMachine mac in machines_search)
            {
                FilterOEEMachineList.Add(mac);
                if (mac.Status == "0")
                    QtyWithoutProducing += 1;
                else
                    QtyInProduction += 1;
            }
        }
    }
}
