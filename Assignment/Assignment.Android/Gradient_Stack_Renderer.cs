using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;

using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Assignment.Controls;
using Android.Graphics.Drawables;
using Assignment.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Gradient_Stack), typeof(Gradient_Stack_Renderer))]
namespace Assignment.Droid
{
    public class Gradient_Stack_Renderer : VisualElementRenderer<StackLayout> {
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }
        private GradientDrawable drawable;
        protected override void DispatchDraw(
        global::Android.Graphics.Canvas canvas)
        {
            var gradient = new Android.Graphics.LinearGradient(0, 0, 0, 2 * Height,
            this.StartColor.ToAndroid(),
            this.EndColor.ToAndroid(),
            Android.Graphics.Shader.TileMode.Clamp);

            var paint = new Android.Graphics.Paint()
            {
                Dither = true
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            drawable = new GradientDrawable();
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as Gradient_Stack;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }

    }
}
    
       