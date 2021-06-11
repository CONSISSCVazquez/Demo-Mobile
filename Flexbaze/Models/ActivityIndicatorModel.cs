using Xamarin.Forms;

namespace Flexbaze.Models
{
    public class ActivityIndicatorModel
    {
        public ActivityIndicator activityIndicator = new ActivityIndicator();
        // anteriormente era un stacklayout de ahi el nombre, se tuvo que cambiar a un frame para ponerlo hasta el frente
        public Frame StackLayoutIndicator = new Frame();
        public ActivityIndicatorModel()
        {
            activityIndicator.HorizontalOptions = LayoutOptions.CenterAndExpand;
            activityIndicator.VerticalOptions = LayoutOptions.CenterAndExpand;
            activityIndicator.IsRunning = true;
            activityIndicator.Color = Color.Blue;
            StackLayoutIndicator.Padding = new Thickness(30, 30, 30, 30);
            AbsoluteLayout.SetLayoutBounds(StackLayoutIndicator, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(StackLayoutIndicator, AbsoluteLayoutFlags.All);
            StackLayoutIndicator.BackgroundColor = Color.FromRgba(50, 50, 51, .8);
            StackLayoutIndicator.Content = activityIndicator;
        }
        public void Enable()
        {
            StackLayoutIndicator.IsVisible = true;
            activityIndicator.IsRunning = true;
        }
        public void Disabled()
        {
            StackLayoutIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
        }
    }
}
