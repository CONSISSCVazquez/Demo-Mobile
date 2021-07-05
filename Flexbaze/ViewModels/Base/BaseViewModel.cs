using Flexbaze.Views;

namespace Flexbaze.ViewModels.Base
{
    public class BaseViewModel
    {
        IndicatorLoading indicatorLoading;
        public BaseViewModel()
        {
            indicatorLoading = new IndicatorLoading();
        }

        public void showIndicator()
        {
            _ = indicatorLoading.Show();
        }

        public void closeIndicator()
        {
            indicatorLoading.Hide();
        }
    }
}
