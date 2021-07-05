using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Flexbaze.Util;
using Flexbaze.Views;
using Flexbaze.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Device = Xamarin.Forms.Device;
using Flexbaze.Resources;
using System.Threading;
using System.Globalization;

namespace Flexbaze
{
    public partial class App : Application
    {
        private static string extraMessage;
        public static CultureInfo Language { get; set; }
        public static MasterDetailPage MasterDP { get; set; }
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static string AppVersion { get; set; }
        public static Page currentPage { get; set; }
        public static bool OnResumed { get; private set; }

        public App()
        {
            Language = Thread.CurrentThread.CurrentUICulture;
            if (Settings.Language != "y" && Settings.Language != Language.Name)
                Language = new CultureInfo(Settings.Language);
            AppResources.Culture = Language;
            InitializeComponent();
            MainPage = new Login();
            currentPage = MainPage;
        }

        protected override void OnStart()
        {
            extraMessage = string.Empty;

            #region OneSignal PushNotificatoin

            App.RemoveExternalUserId();

            //Suscribirse a un determinado Segmento
            //App.sendTagSegment("Desarrollo");

            //Suscribirse por custom UserId
            App.SetExternalUserId();

            Delay();

            /*
            //Cuenta de Prueba OneSignal
            OneSignal.Current.StartInit("a7f77124-dfca-4581-9324-32529f9c2509")
            .HandleNotificationReceived(HandleNotificationReceived)
            .HandleNotificationOpened(HandleNotificationOpened)
            .EndInit();
            */


            //Cuenta Produccion de OneSignal
            OneSignal.Current.StartInit("1f99fe5e-b3dc-4328-91ef-8b2bf0182d43")
                .HandleNotificationReceived(HandleNotificationReceived)
                .HandleNotificationOpened(HandleNotificationOpened)
                .EndInit();


            //Suscribirse a un determinado Segmento
            App.obtenIdsAvailable();

            #endregion OneSignal PushNotification
        }

        private async void Delay()
        {
            await Task.Delay(2000);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            OnResumed = false;
        }

        #region Eventos PushNotificatoin
        private static void HandleNotificationReceived(OSNotification notification)
        {
            OSNotificationPayload payload = notification.payload;

            string message = payload.body;
            System.Diagnostics.Debug.WriteLine("HandleNotificationReceived: " + message);
            System.Diagnostics.Debug.WriteLine("displayType: " + notification.displayType);
            extraMessage = "Notification received with text: " + message;
        }

        private static void HandleNotificationOpened(OSNotificationOpenedResult result)
        {
            OSNotificationPayload payload = result.notification.payload;
            Dictionary<string, object> additionalData = payload.additionalData;
            string message = payload.body;
            string actionID = result.action.actionID;
            System.Diagnostics.Debug.WriteLine("HandleNotificationOpened: " + message);
            extraMessage = "Notification opened with text: " + message;
            if (additionalData != null)
            {
                if (additionalData.ContainsKey("parametro1"))
                {
                    extraMessage = additionalData["parametro1"].ToString();
                    System.Diagnostics.Debug.WriteLine("additionalData - parametro1:  " + extraMessage);

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Alerts alerta = new Alerts();
                        alerta = JsonConvert.DeserializeObject<Alerts>(extraMessage);
                    });
                }
            }
            //if (actionID != null)
            //{
            //    switch (actionID)
            //    {                    
            //        default:
            //            if (currentPage != null)
            //            {
            //                Device.BeginInvokeOnMainThread(() =>
            //                {
            //                    Master mstrView = new Master();
            //                    mstrView.NotificationOpened();
            //                });
            //            }
            //            break;
            //    }
            //    extraMessage = "Pressed ButtonId: " + actionID;
            //}
        }

        public static void RemoveExternalUserId()
        {
            OneSignal.Current.RemoveExternalUserId();
        }
        private static void IdsAvailable(string userID, string pushToken)
        {
            //Para obtener el userID y pushToken
            System.Diagnostics.Debug.WriteLine("UserID:" + userID);
            System.Diagnostics.Debug.WriteLine("pushToken:" + pushToken);
        }
        public static void sendTagSegment(string strSegment)
        {
            OneSignal.Current.SendTag(strSegment, "1");
        }
        public static void SetExternalUserId()
        {
            string externalId = Settings.Node;
            OneSignal.Current.SetExternalUserId(externalId);
        }

        public static void obtenIdsAvailable()
        {
            OneSignal.Current.IdsAvailable(IdsAvailable);
        }

        #endregion Eventos
    }
}
