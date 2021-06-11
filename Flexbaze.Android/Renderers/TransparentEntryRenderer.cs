using Android.Content;
using Android.Graphics.Drawables;
using Flexbaze.Droid.Renderers;
using Flexbaze.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TransparentEntry), typeof(TransparentEntryRenderer))]
namespace Flexbaze.Droid.Renderers
{
    class TransparentEntryRenderer : EntryRenderer
    {
        public TransparentEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();

                gd.SetColor(Android.Graphics.Color.Transparent);
                this.Control.SetBackground(gd);
                this.Control.SetPadding(20, 0, 0, 0);

            }
        }
    }
}