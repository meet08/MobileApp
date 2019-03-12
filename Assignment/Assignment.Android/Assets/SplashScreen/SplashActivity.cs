using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Assignment.Droid.SplashScreen
{
    [Activity(Label = "FireChat",
         Icon = "@drawable/launchScreen",
         Theme = "@style/Theme.Splash",
         MainLauncher = true,
         NoHistory = true)]
    public class SplashActivity:Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.SplashLayout);

            Thread.Sleep(100);

            StartActivity(typeof(MainActivity));

            // Create your application here
        }
    }
}