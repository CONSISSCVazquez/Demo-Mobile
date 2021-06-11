using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Flexbaze.Models;
using Flexbaze.Resources;

namespace Flexbaze.ViewModels
{
    class SupportDetailViewModel : INotifyPropertyChanged
    {
        private Request _request = new Request();
        private string _title;
        private string _plant;
        private string _cell;
        private string _machine;
        private string _status;
        private string _mainDetail;
        private User _reportedBy;
        private User _resolvedBy;
        private string _imgStatus;
        private List<TicketStatus> _statusList;
        private List<string> _detailList;

        public string Title
        {
            get => _title;
            private set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Plant
        {
            get => _plant;
            private set
            {
                _plant = value;
                OnPropertyChanged();
            }
        }

        public string Cell
        {
            get => _cell;
            private set
            {
                _cell = value;
                OnPropertyChanged();
            }
        }

        public string Machine
        {
            get => _machine;
            private set
            {
                _machine = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            private set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public string MainDetail
        {
            get => _mainDetail;
            private set
            {
                _mainDetail = value;
                OnPropertyChanged();
            }
        }

        public string ImgStatus
        {
            get => _imgStatus;
            private set
            {
                _imgStatus = value;
                OnPropertyChanged();
            }
        }

        public User ReportedBy
        {
            get => _reportedBy;
            private set
            {
                _reportedBy = value;
                OnPropertyChanged();
            }
        }

        public User ResolvedBy
        {
            get => _resolvedBy;
            private set
            {
                _resolvedBy = value;
                OnPropertyChanged();
            }
        }

        public List<TicketStatus> StatusList
        {
            get => _statusList;
            private set
            {
                _statusList = value;
                OnPropertyChanged();
            }
        }

        public List<string> DetailList
        {
            get => _detailList;
            private set
            {
                _detailList = value;
                OnPropertyChanged();
            }
        }


        public SupportDetailViewModel(string ticketId, string status)
        {
            Ini(ticketId);
            GetDetails(ticketId, status);
        }

        private void Ini(string ticketId)
        {
            Title = AppResources.DetailPageTitle + " " + ticketId;
        }

        private void GetDetails(string ticketId, string status)
        {
            Plant = "1";
            Cell = "C1";
            Machine = "M301";
            Status = status;
            if (status.Equals(AppResources.InProcessLabel))
            {
                ImgStatus = "clock.png";
            } else
            {
                if (status.Equals(AppResources.ClosedLabel))
                {
                    ImgStatus = "done.png";
                }
            }
            ReportedBy = new User
            {
                ImgUser = "female.png",
                Name = "Sofía Herrera",
                JobTitle = "Inspector de Calidad"
            };
            ResolvedBy = new User
            {
                ImgUser = "Andres.png",
                Name = "Roberto Gómez",
                JobTitle = "Técnico"
            };
            StatusList = new List<TicketStatus>();
            TicketStatus t1 = new TicketStatus {
                Status = AppResources.OpenLabel,
                ImgStatus = "open.png",
                Hour = "07 Julio 2020 - 10:29 AM"
            };
            TicketStatus t2 = new TicketStatus
            {
                Status = AppResources.InProcessLabel,
                ImgStatus = "clock.png",
                Hour = "07 Julio 2020 - 11:00 AM"
            };
            TicketStatus t3 = new TicketStatus
            {
                Status = AppResources.ClosedLabel,
                ImgStatus = "done.png",
                Hour = "07 Julio 2020 - 12:00 PM"
            };
            StatusList.Add(t1);
            StatusList.Add(t2);
            if (status.Equals(AppResources.ClosedLabel))
            {
                StatusList.Add(t3);
            }
            string det1 = AppResources.LackMaterial;
            string det2 = AppResources.FailureMold + " 392";
            string det3 = AppResources.Maintenance;
            string det4 = AppResources.LeakLabel;
            string det5 = AppResources.MinorIncident;
            string det6 = AppResources.LackMaterial;
            List<string> details = new List<string>();
            DetailList = new List<string>();
            details.Add(det1);
            details.Add(det2);
            details.Add(det3);
            details.Add(det4);
            details.Add(det5);
            details.Add(det6);
            MainDetail = details[Int32.Parse(ticketId) - 1];
            DetailList.Add(AppResources.MainDetail);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
