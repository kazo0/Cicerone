using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views;

namespace Cicerone.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : MvxFormsSplashScreenAppCompatActivity<MvxFormsAndroidSetup<Core.App, App>, Core.App, App>
    {
        public SplashActivity()
			: base(Resource.Layout.SplashScreen)
        {
        }

		protected override Task RunAppStartAsync(Bundle bundle)
		{
            StartActivity(typeof(RootActivity));
            return base.RunAppStartAsync(bundle);
		}

        /*
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        public override void OnBackPressed() { }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
			//Startup work here
            StartActivity(new Intent(Application.Context, typeof(RootActivity)));
        }*/

    }
}
