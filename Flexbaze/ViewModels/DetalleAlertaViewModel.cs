using Flexbaze.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Flexbaze.ViewModels
{
    class DetalleAlertaViewModel : INotifyPropertyChanged
    {
        private Request _request = new Request();
        private Notifications _notification = new Notifications();
        private string _node;
        private ListView PullToRefresh;
        private Entry _message;
        private ListView _listViewMessages;
        private bool _executeButton;
        public bool CanUpdate { get; set; } = true;
        public Command SendMessage { get; private set; }
        public Command Refresh { get; private set; }
        public Flexbaze_Colors Colors { get; private set; } = new Flexbaze_Colors();
        public event PropertyChangedEventHandler PropertyChanged;
        public bool ExecuteButton
        {
            get { return _executeButton; }
            set
            {
                if (_executeButton == value)
                    return;
                _executeButton = value;
                OnPropertyChanged("ExecuteButton");
            }
        }

        public Notifications Notification {
            get => _notification;
            private set
            {
                _notification = value;
                OnPropertyChanged();
            }
        }

        public DetalleAlertaViewModel(ListView PullToRefresh, string node, Entry Message, ListView ListViewMessages)
        {
            _listViewMessages = ListViewMessages;
            this.PullToRefresh = PullToRefresh;
            _node = node;
            _message = Message;
            ExecuteButton = true;
            Ini();
        }

        public DetalleAlertaViewModel(ListView PullToRefresh, Models.Alerts alerta, Entry Message, ListView ListViewMessages)
        {
            _listViewMessages = ListViewMessages;
            this.PullToRefresh = PullToRefresh;
            _node = alerta.Node;
            _message = Message;
            Notification.Header = alerta;
            ExecuteButton = true;
            Ini();
        }

        private async void Ini()
        {
            SendMessage = new Command(SaveMessage,EvalButton);
            Refresh = new Command( async () => {
                await GetNotificationByNode(false);
            });
            await GetNotificationByNode(false);
            await Task.Delay(5000);
            Update();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void Update (){
            try
            {
                if (CanUpdate)
                {
                    await GetNotificationByNode(true);
                    await Task.Delay(5000);
                    Update();
                }
            }
            catch(Exception e)
            {
                await Task.Delay(5000);
                Update();
                Console.Write(e);
            }
        }

        public async void SaveMessage(object nothing)
        {
            ExecuteButton = false;
            ((Command)this.SendMessage).ChangeCanExecute();
            string message = _message.Text;
            if (message == "")
            {
                ExecuteButton = true;
                ((Command)this.SendMessage).ChangeCanExecute();
                return;
            }
            _message.Text = "Publicando...";
            await Task.Delay(1000);
            _message.Text = "";
            //string json = await _request.GetData("app", "{\"metodo\": \"app_insertMessageToNotification\",\"attr\": {\"clave\":\"" + Settings.Client + "\",\"notificationNode\":\"" + _node + "\",\"message\": \"" + message + "\",\"user\": \"" + Settings.Node + "\"}}");
            await GetNotificationByNode(true);

            ExecuteButton = true;
            ((Command)this.SendMessage).ChangeCanExecute();
        }

        private bool EvalButton(object nothing)
        {
            return ExecuteButton;
        }

        private async Task GetNotificationByNode(bool focusLastItem){
            try
            {
                NotificationsModel result;
                PullToRefresh.IsRefreshing = false;
            }
            catch (Exception e)
            {
                PullToRefresh.IsRefreshing = false;
                Console.WriteLine(e);
            }
        }
    }
}