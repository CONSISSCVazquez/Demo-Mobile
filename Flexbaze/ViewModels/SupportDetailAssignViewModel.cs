using Flexbaze.Models;
using Flexbaze.Resources;
using Flexbaze.ViewModels.Base;
using Flexbaze.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Flexbaze.ViewModels
{
    class SupportDetailAssignViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Request _request = new Request();
        private ObservableCollection<UserType> _userList;
        private double _heightListViewUser;
        private string _ticketId;
        private string _status;
        private string _selectedUser;
        private Boolean _assignOk;
        public Command CmdAssign { get; set; }
        public Command CmdSelectedUser { get; set; }
        public INavigation Navigation { get; set; }

        List<UserType> users = new List<UserType>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<UserType> UserList
        {
            get => _userList;
            private set
            {
                _userList = value;
                OnPropertyChanged();
            }
        }

        public double HeightListViewUser
        {
            get => _heightListViewUser;
            private set
            {
                _heightListViewUser = value;
                OnPropertyChanged();
            }
        }

        public string TicketId
        {
            get => _ticketId;
            private set
            {
                _ticketId = value;
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

        public string SelectedUser
        {
            get => _selectedUser;
            private set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public Boolean AssignOk
        {
            get => _assignOk;
            private set
            {
                _assignOk = value;
                OnPropertyChanged();
            }
        }

        public SupportDetailAssignViewModel(string ticketId, string status, INavigation navigation) : base()
        {
            Ini(ticketId, status, navigation);
        }

        private async void Ini(string ticketId, string status, INavigation navigation)
        {
            showIndicator();
            Navigation = navigation;
            TicketId = ticketId;
            Status = status;
            UserList = new ObservableCollection<UserType>();
            users = await GetTechnicians();
            foreach (UserType usr in users)
            {
                UserList.Add(usr);
            }

            HeightListViewUser = (100 * UserList.Count) + 10;

            CmdAssign = new Command(async (param) =>
            {
                if (SelectedUser != null)
                {
                    AssignOk = await AssignTicket(param.ToString());
                    if (AssignOk)
                    {
                        var toastAlert = new CustomToast(Color.Green, AppResources.DoneAssignTicketAlert, "done_white.png");
                        _ = toastAlert.Show();

                        _ = Navigation.PopAsync();
                    }
                    else
                    {
                        var toastAlert = new CustomToast(Color.Red, AppResources.FailAssignTicketAlert, "close.png");
                        _ = toastAlert.Show();

                        _ = Navigation.PopAsync();
                    }
                }
            });

            CmdSelectedUser = new Command((param) =>
                            SelectUser(param.ToString()));
            closeIndicator();
        }

        public void searchUser(string search)
        {
            UserList = new ObservableCollection<UserType>();

            var users_search = search.Length > 0 ? users.FindAll(x => (x.FirstName + " " + x.LastName).ToLower().Contains(search.ToLower())) : users;

            foreach (UserType usr in users_search)
            {
                UserList.Add(usr);
            }

            HeightListViewUser = (100 * UserList.Count) + 10;
        }

        public async Task<List<UserType>> GetTechnicians()
        {
            List<UserType> result = new List<UserType>()
            {
                new UserType()
                {
                    Id = "1",
                    FirstName = "Ricardo",
                    LastName = "García",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "2",
                        Name = "Ricardo Garcia",
                        Picture = "https://flexbaze-demo.s3.amazonaws.com/pp.jpeg"
                    },
                },
                new UserType()
                {
                    Id = "4",
                    FirstName = "Juan",
                    LastName = "Perez",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "3",
                        Name = "Juan Perez",
                        Picture = "Andres.jpg"
                    },
                },
                new UserType()
                {
                    Id = "3",
                    FirstName = "John",
                    LastName = "Doe",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "4",
                        Name = "John Doe",
                        Picture = "Consiss1.png"
                    },
                },
                new UserType()
                {
                    Id = "7",
                    FirstName = "Norma",
                    LastName = "Perez",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "6",
                        Name = "Norma Perez",
                        Picture = "user_icon.png"
                    },
                },
                new UserType()
                {
                    Id = "8",
                    FirstName = "Martha",
                    LastName = "Jimenez",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "7",
                        Name = "Martha Jimenez",
                        Picture = "user_icon.png"
                    },
                },
                new UserType()
                {
                    Id = "9",
                    FirstName = "María",
                    LastName = "López",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "8",
                        Name = "María López",
                        Picture = "user_icon.png"
                    },
                },
                new UserType()
                {
                    Id = "10",
                    FirstName = "Patricia",
                    LastName = "Medina",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "9",
                        Name = "Patricia Medina",
                        Picture = "user_icon.png"
                    },
                },
                new UserType()
                {
                    Id = "11",
                    FirstName = "Juana",
                    LastName = "Cortez",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "10",
                        Name = "Juana Cortez",
                        Picture = "user_icon.png"
                    },
                },
                new UserType()
                {
                    Id = "13",
                    FirstName = "Raquel",
                    LastName = "Enriquez",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "12",
                        Name = "Raquel Enriquez",
                        Picture = "user_icon.png"
                    },
                },
                new UserType()
                {
                    Id = "14",
                    FirstName = "Paulina",
                    LastName = "García",
                    Groups = new List<GroupType>()
                    {
                        new GroupType()
                        {
                            Id = "4",
                            Name = "technician"
                        }
                    },
                    Profile = new ProfileType()
                    {
                        Id = "13",
                        Name = "Paulina García",
                        Picture = "user_icon.png"
                    },
                }
            };
            return result;
        }

        public async Task<Boolean> AssignTicket(string user)
        {
            Boolean assignOk = false;
            if (user != null)
            {
                AssignTicket assign = await AssignTicketAsync(user, TicketId);
                if (assign.Ticket.AssignedTo.Id == user)
                    assignOk = true;
            }
            return assignOk;
        }

        public async Task<AssignTicket> AssignTicketAsync(string user, string ticket)
        {
            AssignTicket result = new AssignTicket();
            result.Ticket = new SupportTicketType()
            {
                AssignedTo = new UserType()
                {
                    Id = user
                }
            };
            return result;
        }

        public void SelectUser(string userId)
        {
            SelectedUser = userId;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
