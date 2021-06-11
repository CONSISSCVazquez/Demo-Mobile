using Flexbaze.Util;
using Flexbaze.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace Flexbaze
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Master = new Master();
            if (Settings.IsLoggedIn == "false" || Settings.IsLoggedIn == "")
            {
                Detail = new NavigationPage(new Login());
                App.MasterDP = this;
            }
            else
            {
                NavigationPage p = new NavigationPage(new Dashboard());
                p.BarBackgroundColor = Color.FromHex("#101630");
                Detail = p;
                App.MasterDP = this;
            }
            App.Current.MainPage = this;
        }
    }
}