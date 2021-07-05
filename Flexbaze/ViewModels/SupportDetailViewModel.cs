using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Flexbaze.Converters;
using Flexbaze.Models;
using Flexbaze.Resources;
using Flexbaze.Util;
using Flexbaze.ViewModels.Base;
using Flexbaze.Views;
using Xamarin.Forms;

namespace Flexbaze.ViewModels
{
    class SupportDetailViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Request _request = new Request();
        private string _title;
        private string _id;
        private string _plant;
        private string _cell;
        private string _machine;
        private string _status;
        private string _mainDetail;
        private User _reportedBy;
        private User _resolvedBy;
        private string _imgStatus;
        private string _imgCurrentUser;
        private string _btnAssignText;
        private bool _btnAssignIsEnabled;
        private bool _changedOk;
        private List<TicketStatus> _statusList;
        private ObservableCollection<TicketEventType> _detailList;
        private List<string> _statusSelectList;
        private string _statusSelected;
        private bool _btnChangeStatIsEnabled;
        public Command CmdAssign { get; private set; }
        public Command CmdAddDetails { get; private set; }
        public Command CmdChangeStatus { get; private set; }

        public INavigation Navigation { get; set; }

        private double _heightListDetail;

        public double HeightListDetail
        {
            get => _heightListDetail;
            private set
            {
                _heightListDetail = value;
                OnPropertyChanged();
            }
        }
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

        public string Id
        {
            get => _id;
            private set
            {
                _id = value;
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

        public string ImgCurrentUser
        {
            get => _imgCurrentUser;
            private set
            {
                _imgCurrentUser = value;
                OnPropertyChanged();
            }
        }

        public string BtnAssignText
        {
            get => _btnAssignText;
            private set
            {
                _btnAssignText = value;
                OnPropertyChanged();
            }
        }

        public bool BtnAssignIsEnabled
        {
            get => _btnAssignIsEnabled;
            private set
            {
                _btnAssignIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool ChangedOk
        {
            get => _changedOk;
            private set
            {
                _changedOk = value;
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

        public ObservableCollection<TicketEventType> DetailList
        {
            get => _detailList;
            private set
            {
                _detailList = value;
                OnPropertyChanged();
            }
        }

        public List<string> StatusSelectList
        {
            get => _statusSelectList;
            private set
            {
                _statusSelectList = value;
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

        public bool BtnChangeStatIsEnabled
        {
            get => _btnChangeStatIsEnabled;
            private set
            {
                _btnChangeStatIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public SupportDetailViewModel(TicketComplete ticket, string Factory, INavigation navigation) : base()
        {
            showIndicator();
            Id = ticket.Id;
            Ini(navigation);
            Plant = Factory;
            Cell = ticket.Cell.Name;
            Machine = ticket.Machine.Name;
            Status = ticket.Status;
            ImgCurrentUser = Settings.Picture == null || Settings.Picture == "" ? "user_icon.png" : Settings.Picture;
            StatusSelectList = new List<string>();
            if (Status.Equals(AppResources.OpenLabel))
            {
                ImgStatus = "open.png";
                BtnAssignIsEnabled = true;
                BtnAssignText = AppResources.AssignLabel;
                StatusSelectList.Add(AppResources.ChangeStatus);
                StatusSelectList.Add(AppResources.ClosedLabel);
                StatusSelected = AppResources.ChangeStatus;
                BtnChangeStatIsEnabled = false;
            }
            else
            {
                if (Status.Equals(AppResources.InProcessLabel))
                {
                    ImgStatus = "clock.png";
                    BtnAssignIsEnabled = true;
                    BtnAssignText = AppResources.Reassign;
                    StatusSelectList.Add(AppResources.ChangeStatus);
                    StatusSelectList.Add(AppResources.ClosedLabel);
                    StatusSelected = AppResources.ChangeStatus;
                    BtnChangeStatIsEnabled = true;
                }
                else
                {
                    if (Status.Equals(AppResources.ClosedLabel))
                    {
                        ImgStatus = "done.png";
                        BtnAssignIsEnabled = true;
                        BtnAssignText = AppResources.Reassign;
                        BtnChangeStatIsEnabled = false;
                    }
                }
            }
            ReportedBy = new User
            {
                ImgUser = ticket.ReportedBy.Profile.Picture.Equals(null) || ticket.ReportedBy.Profile.Picture.Equals("") ? "user_icon.png" : ticket.ReportedBy.Profile.Picture,
                Name = ticket.ReportedBy.Profile.Name.Equals(null) || ticket.ReportedBy.Profile.Name.Equals("") ? ticket.ReportedBy.FirstName + " " + ticket.ReportedBy.LastName : ticket.ReportedBy.Profile.Name,
                JobTitle = ticket.ReportedBy.Groups.Count > 0 ? ticket.ReportedBy.Groups[0].Name : ""
            };
            ResolvedBy = new User
            {
                ImgUser = ticket.AssignedTo.Profile.Picture.Equals(null) || ticket.AssignedTo.Profile.Picture.Equals("") ? "user_icon.png" : ticket.AssignedTo.Profile.Picture,
                Name = ticket.AssignedTo.Profile.Name.Equals(null) || ticket.AssignedTo.Profile.Name.Equals("") ? ticket.AssignedTo.FirstName + " " + ticket.AssignedTo.LastName : ticket.AssignedTo.Profile.Name,
                JobTitle = ticket.AssignedTo.Groups.Count > 0 ? ticket.AssignedTo.Groups[0].Name : ""
            };
            MainDetail = ticket.Description;
            StatusList = new List<TicketStatus>();
            DetailList = new ObservableCollection<TicketEventType>();
            MonthNumberToStringConverter conv = new MonthNumberToStringConverter();
            if (ticket.StartedAt != null)
            {
                TicketStatus ts = new TicketStatus();
                ts.Status = AppResources.OpenLabel;
                ts.ImgStatus = "open.png";
                ts.Hour = AppResources.DateFormat.Equals("dd-MMM-yyyy") ? ticket.StartedAt.ToString("dd") + " " + conv.Convert(ticket.StartedAt.ToString("MM")) + " " + ticket.StartedAt.ToString("yyyy hh:mm tt") : conv.Convert(ticket.StartedAt.ToString("MM")) + " " + ticket.StartedAt.ToString("dd") + " " + ticket.StartedAt.ToString("yyyy hh:mm tt");
                StatusList.Add(ts);
            }
            if (ticket.Events != null)
            {
                foreach (TicketEventType ev in ticket.Events)
                {
                    TicketStatus t1 = new TicketStatus();
                    if (ev.EventType != null && ev.EventType != "" && ev.EventType != "Detail")
                    {
                        switch (ev.Description.Substring(0, 14))
                        {
                            case "Ticket assigna":
                                t1.Status = AppResources.InProcessLabel;
                                t1.ImgStatus = "clock.png";
                                t1.Hour = AppResources.DateFormat.Equals("dd-MMM-yyyy") ? ev.Timestamp.ToString("dd") + " " + conv.Convert(ev.Timestamp.ToString("MM")) + " " + ev.Timestamp.ToString("yyyy hh:mm tt") : conv.Convert(ev.Timestamp.ToString("MM")) + " " + ev.Timestamp.ToString("dd") + " " + ev.Timestamp.ToString("yyyy hh:mm tt");
                                StatusList.Add(t1);
                                break;
                            case "Ticket cerrado":
                                t1.Status = AppResources.ClosedLabel;
                                t1.ImgStatus = "done.png";
                                t1.Hour = AppResources.DateFormat.Equals("dd-MMM-yyyy") ? ev.Timestamp.ToString("dd") + " " + conv.Convert(ev.Timestamp.ToString("MM")) + " " + ev.Timestamp.ToString("yyyy hh:mm tt") : conv.Convert(ev.Timestamp.ToString("MM")) + " " + ev.Timestamp.ToString("dd") + " " + ev.Timestamp.ToString("yyyy hh:mm tt");
                                StatusList.Add(t1);
                                break;
                        }
                    }
                }

                foreach (TicketEventType t in ticket.Events)
                {
                    if (t.EventType != null)
                    {
                        if (t.EventType.Equals("Detail"))
                        {
                            if (t.User.Profile.Picture == null || t.User.Profile.Picture == "")
                            {
                                t.User.Profile.Picture = "user_icon.png";
                            }
                            DetailList.Add(t);
                        }
                    }
                }
                HeightListDetail = (50 * DetailList.Count) + 40;
            }
            closeIndicator();
        }

        private void Ini(INavigation navigation)
        {
            Navigation = navigation;
            Title = AppResources.DetailPageTitle + " " + Id;
            CmdChangeStatus = new Command(async (param) =>
            {
                var toastAlert = new DisplayAlertPage(AppResources.CloseStatus, AppResources.CloseStatusMessage, AppResources.Cancel, AppResources.Accept);
                var result = await toastAlert.Show();
                if (result)
                {
                    ChangedOk = await ChangeStatus();
                    if (ChangedOk)
                    {
                        var toastAlertOk = new CustomToast(Color.Green, AppResources.DoneCloseTicketAlert, "done_white.png");
                        _ = toastAlertOk.Show();

                        _ = Navigation.PopAsync();
                    }
                    else
                    {
                        var toastAlertFail = new CustomToast(Color.Red, AppResources.FailCloseTicketAlert, "close.png");
                        _ = toastAlertFail.Show();

                        _ = Navigation.PopAsync();
                    }
                }
            });
        }

        public async Task<Boolean> ChangeStatus()
        {
            //Boolean changedOk = false;
            //AssignTicket assign = await CloseTicketAsync(Id);
            //if (assign.Ticket.Status != null)
            //{
            //    if (assign.Ticket.Status == "CLOSED")
            //        changedOk = true;
            //}
            Boolean changedOk = true;
            return changedOk;
        }

        public async Task AddDetail(string commentary)
        {
            var toastAlert = new DisplayAlertPage(AppResources.AddDetail, AppResources.AddDetailMessage, AppResources.Cancel, AppResources.Accept);
            var result = await toastAlert.Show();
            if (result)
            {

                AddTicketEvent ate = await AddDetailAsync(commentary);
                if (ate.TicketEvent != null)
                {
                    var toastAlertOk = new CustomToast(Color.Green, AppResources.DoneAddDetailAlert, "done_white.png");
                    _ = toastAlertOk.Show();

                    _ = Navigation.PopAsync();
                    DetailList.Add(new TicketEventType() { Description = commentary, User = new UserType() { Profile = new ProfileType() { Picture = Settings.Picture != null && Settings.Picture != "" ? Settings.Picture : "user_icon.png" } } });
                    HeightListDetail = (50 * DetailList.Count) + 60;
                }
                else
                {
                    var toastAlertFail = new CustomToast(Color.Green, AppResources.FailAddDetailAlert, "done_white.png");
                    _ = toastAlertFail.Show();

                    _ = Navigation.PopAsync();
                }
            }
        }

        public async Task<AddTicketEvent> AddDetailAsync(string commentary)
        {
            AddTicketEvent result = new AddTicketEvent();
            result.TicketEvent = new TicketEventType()
            {
                Id = Id,
                Description = commentary,
                Timestamp = DateTime.Now,
                EventType = "Detail"
            };
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
