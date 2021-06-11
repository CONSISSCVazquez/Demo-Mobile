using Flexbaze.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Flexbaze.ViewModels
{

    class ChatViewDetailModel : INotifyPropertyChanged
    {
        private string _identifier;
        private string _title;
        private string _pictureChat;
        private ObservableCollection<ChatDetailMessages> _chats;

        public ObservableCollection<ChatDetailMessages> Chats
        {
            get => _chats;
            private set
            {
                _chats = value;
                OnPropertyChanged();
            }
        }

        public string Identifier
        {
            get => _identifier;
            private set
            {
                _identifier = value;
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

        public string PictureChat
        {
            get => _pictureChat;
            private set
            {
                _pictureChat = value;
                OnPropertyChanged();
            }
        }

        public ChatViewDetailModel(string Id)
        {
            Ini(Id);
        }

        private void Ini(string Id)
        {
            GetData(Id);
        }

        public void GetData(string Id)
        {
            ObservableCollection<ChatDetailMessages> chatsDet = new ObservableCollection<ChatDetailMessages>();
            switch (Id)
            {
                case "1":
                    ChatDetailMessages chat1 = new ChatDetailMessages()
                    {
                        Id = "1",
                        Message = "Hola Manuel",
                        Date = "2020-07-05",
                        Hour = "11:15 AM",
                        IsMyMessage = true,
                        FrameColor = Color.FromHex("#336ef4")
                    };
                    ChatDetailMessages chat2 = new ChatDetailMessages()
                    {
                        Id = "2",
                        Message = "Buenos días",
                        Date = "2020-07-05",
                        Hour = "11:15 AM",
                        IsMyMessage = true,
                        FrameColor = Color.FromHex("#336ef4")
                    };
                    ChatDetailMessages chat3 = new ChatDetailMessages()
                    {
                        Id = "3",
                        Message = "Buen día",
                        Date = "2020-07-05",
                        Hour = "11:16 AM",
                        IsMyMessage = false,
                        FrameColor = Color.FromHex("#202850")
                    };
                    chatsDet.Add(chat1);
                    chatsDet.Add(chat2);
                    chatsDet.Add(chat3);

                    Identifier = "1";
                    Title = "Manuel López";
                    PictureChat = "Andres.jpg";
                    Chats = chatsDet;
                    break;
                case "2":
                    ChatDetailMessages chat4 = new ChatDetailMessages()
                    {
                        Id = "1",
                        Message = "Hola Ricardo",
                        Date = "2020-07-05",
                        Hour = "11:15 AM",
                        IsMyMessage = true,
                        FrameColor = Color.FromHex("#336ef4")
                    };
                    ChatDetailMessages chat5 = new ChatDetailMessages()
                    {
                        Id = "2",
                        Message = "Buenos días",
                        Date = "2020-07-05",
                        Hour = "11:15 AM",
                        IsMyMessage = true,
                        FrameColor = Color.FromHex("#336ef4")
                    };
                    ChatDetailMessages chat6 = new ChatDetailMessages()
                    {
                        Id = "3",
                        Message = "Hola, buen día",
                        Date = "2020-07-05",
                        Hour = "11:16 AM",
                        IsMyMessage = false,
                        FrameColor = Color.FromHex("#202850")
                    };
                    chatsDet.Add(chat4);
                    chatsDet.Add(chat5);
                    chatsDet.Add(chat6);

                    Identifier = "2";
                    Title = "Ricardo H";
                    PictureChat = "caution.png";
                    Chats = chatsDet;
                    break;
                case "3":
                    ChatDetailMessages chat7 = new ChatDetailMessages()
                    {
                        Id = "1",
                        Message = "Hola Ernesto",
                        Date = "2020-07-18",
                        Hour = "09:15 AM",
                        IsMyMessage = true,
                        FrameColor = Color.FromHex("#336ef4")
                    };
                    ChatDetailMessages chat8 = new ChatDetailMessages()
                    {
                        Id = "2",
                        Message = "Hola Nicolás",
                        Date = "2020-07-18",
                        Hour = "09:16 AM",
                        IsMyMessage = false,
                        FrameColor = Color.FromHex("#202850")
                    };
                    ChatDetailMessages chat9 = new ChatDetailMessages()
                    {
                        Id = "3",
                        Message = "¿Cómo te puedo ayudar?",
                        Date = "2020-07-18",
                        Hour = "09:16 AM",
                        IsMyMessage = false,
                        FrameColor = Color.FromHex("#202850")
                    };
                    ChatDetailMessages chat10 = new ChatDetailMessages()
                    {
                        Id = "4",
                        Message = "En la celda 5 tienen un problema con la máquina 6, ¿podrías ir a revisar qué sucede?",
                        Date = "2020-07-18",
                        Hour = "09:16 AM",
                        IsMyMessage = true,
                        FrameColor = Color.FromHex("#336ef4")
                    };
                    ChatDetailMessages chat11 = new ChatDetailMessages()
                    {
                        Id = "5",
                        Message = "Claro! Voy para allá, no me tardo",
                        Date = "2020-07-18",
                        Hour = "09:18 AM",
                        IsMyMessage = false,
                        FrameColor = Color.FromHex("#202850")
                    };
                    chatsDet.Add(chat7);
                    chatsDet.Add(chat8);
                    chatsDet.Add(chat9);
                    chatsDet.Add(chat10);
                    chatsDet.Add(chat11);

                    Identifier = "3";
                    Title = "Ernesto Matuz";
                    PictureChat = "Consiss1.png";
                    Chats = chatsDet;
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
