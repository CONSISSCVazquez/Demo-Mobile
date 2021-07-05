using Android.Content;
using Flexbaze.Droid.Renderers;
using Flexbaze.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NormalTextButton), typeof(NormalTextButtonRenderer))]
namespace Flexbaze.Droid.Renderers
{
    public class NormalTextButtonRenderer : ButtonRenderer
    {
        public NormalTextButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(new Android.Widget.Button(Context));
            }
            else
            {
                Control.SetAllCaps(false);
            }
        }
    }
}
