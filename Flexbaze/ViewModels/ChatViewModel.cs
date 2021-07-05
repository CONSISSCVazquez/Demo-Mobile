using Flexbaze.Models;
using Flexbaze.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Flexbaze.ViewModels
{
    class ChatViewModel : INotifyPropertyChanged
    {
        private Request _request = new Request();
        private INavigation _navigation;
        private ObservableCollection<Chat> _chatList;
        private double _heightListViewChat;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Chat> ChatList
        {
            get => _chatList;
            private set
            {
                _chatList = value;
                OnPropertyChanged();
            }
        }

        public double HeightListViewChat
        {
            get => _heightListViewChat;
            private set
            {
                _heightListViewChat = value;
                OnPropertyChanged();
            }
        }

        public ChatViewModel(INavigation nav)
        {
            _navigation = nav;
            Ini();
        }

        private void Ini()
        {
            ChatList = new ObservableCollection<Chat>();
            Chat chat1 = new Chat()
            {
                Id = "1",
                Date = "2020-07-11",
                Hour = "10:12 AM",
                Status = "0",
                Picture = "Andres.jpg",
                Body = "La pieza que les falta se va a tardar de 5 a 7 días hábiles en ...",
                Name = "Manuel López",
                QtyMsgNew = 3,
                HasNewMessages = true,
                IsWriting = false,
                BodyColor = Color.White
            };
            Chat chat2 = new Chat()
            {
                Id = "2",
                Date = "2020-07-11",
                Hour = "10:12 AM",
                Status = "0",
                Picture = "caution.png",
                Body = "Hola, necesitamos material en la celda 5, el material tiene ...",
                Name = "Ricardo H",
                QtyMsgNew = 0,
                HasNewMessages = false,
                IsWriting = false,
                BodyColor = Color.White
            };
            Chat chat3 = new Chat()
            {
                Id = "3",
                Date = "2020-07-11",
                Hour = "10:12 AM",
                Status = "1",
                Picture = "Consiss1.png",
                Body = "Escribiendo ...",
                Name = "Ernesto Matuz",
                QtyMsgNew = 0,
                HasNewMessages = false,
                IsWriting = true,
                BodyColor = Color.FromHex("#336ef4")
            };
            ChatList.Add(chat1);
            ChatList.Add(chat2);
            ChatList.Add(chat3);
            HeightListViewChat = (100 * ChatList.Count) + 10;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void GetChatDetail(string id)
        {
            await _navigation.PushAsync(new ChatViewDetail(id));
        }
    }
}
