using Flexbaze.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(NormalTextButtonRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Flexbaze.iOS.Renderers
{
    public class NormalTextButtonRenderer : MaterialButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.UppercaseTitle = false;
            }
        }
    }
}
