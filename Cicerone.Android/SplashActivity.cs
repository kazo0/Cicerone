using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;

namespace Cicerone.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            StartActivity(new Intent(Application.Context, typeof(RootActivity)));
        }

        public override void OnBackPressed() { }

    }
}
