using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(RoundedCornerList), typeof(RoundedCornerViewRenderer))]
namespace Assignment.Droid
{

    public class RoundedCornerViewRenderer : ViewRenderer
    {
        
        //     protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        //    {
        //        base.OnElementChanged(e);
        //    }

        //    protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        //    {
        //        if (Element == null) return false;

        //        RoundedCornerView rcv = (RoundedCornerView)Element;
        //        this.SetClipChildren(true);

        //        rcv.Padding = new Thickness(0, 0, 0, 0);
        //        //rcv.HasShadow = false;   

        //        int radius = (int)(rcv.RoundedCornerRadius);
        //        if (rcv.MakeCircle)
        //        {
        //            radius = Math.Min(Width, Height) / 2;
        //        }

        //        // When we create a round rect, we will have to double the radius since it is not   
        //        // the same as creating a circle.   
        //        radius *= 2;

        //        try
        //        {
        //            //Create path to clip the child    
        //            var path = new Path();
        //            path.AddRoundRect(new RectF(0, 0, Width, Height),
        //                          new float[] { radius, radius, radius, radius, radius, radius, radius, radius },
        //                          Path.Direction.Ccw);

        //            canvas.Save();
        //            canvas.ClipPath(path);

        //           Properly dispose   
        //            path.Dispose();
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Console.Write(ex.Message);
        //        }

        //        return base.DrawChild(canvas, child, drawingTime);
        //    }
        //}

    }
}