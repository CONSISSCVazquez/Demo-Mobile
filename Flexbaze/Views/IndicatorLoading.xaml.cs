using Rg.Plugins.Popup.Extensions;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flexbaze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndicatorLoading : Rg.Plugins.Popup.Pages.PopupPage
    {
        TaskCompletionSource<bool> _tcs = null;
        SKCanvasView canvasView;
        bool isAnimating;
        Stopwatch stopwatch = new Stopwatch();

        float firstOvalStartAngle = 90;
        float firstOvalSweepAngle = 100;

        float secondOvalStartAngle = 90;
        float secondOvalSweepAngle = 90;

        float thirdOvalStartAngle = 90;
        float thirdOvalSweepAngle = 80;

        SKPaint firstArcPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,

            Color = SKColor.Parse("#788289"),
            StrokeWidth = 20,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round

        };

        SKPaint secondArcPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,

            Color = SKColor.Parse("#C2CAD1"),
            StrokeWidth = 20,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round

        };

        SKPaint thirdArcPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,

            Color = SKColor.Parse("#F9FBFC"),
            StrokeWidth = 20,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round

        };

        public IndicatorLoading()
        {
            InitializeComponent();
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
            isAnimating = true;
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(20), OnTimerTick);
        }

        public async Task<bool> Show()
        {
            _tcs = new TaskCompletionSource<bool>();
            await Navigation.PushPopupAsync(this);

            return await _tcs.Task;
        }

        public void Hide()
        {
            Navigation.PopAllPopupAsync();
        }
        bool OnTimerTick()
        {
            firstOvalStartAngle += 5;
            secondOvalStartAngle += 3;
            thirdOvalStartAngle += 2;
            canvasView.InvalidateSurface();

            return isAnimating;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float left, right;
            float top, bottom;
            right = left = (info.Width - 250) / 2;
            top = bottom = (info.Height - 250) / 2;

            SKRect rect = new SKRect(left, top, info.Width - right, info.Height - bottom);

            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, firstOvalStartAngle, firstOvalSweepAngle);
                canvas.DrawPath(path, firstArcPaint);
            }

            SKRect rect2 = new SKRect(left + 50, top + 50, (info.Width - right) - 50, (info.Height - bottom) - 50);

            using (SKPath path = new SKPath())
            {
                path.AddArc(rect2, secondOvalStartAngle, secondOvalSweepAngle);
                canvas.DrawPath(path, secondArcPaint);
            }

            SKRect rect3 = new SKRect(left + 100, top + 100, (info.Width - right) - 100, (info.Height - bottom) - 100);

            using (SKPath path = new SKPath())
            {
                path.AddArc(rect3, thirdOvalStartAngle, thirdOvalSweepAngle);
                canvas.DrawPath(path, thirdArcPaint);
            }
        }
    }
}