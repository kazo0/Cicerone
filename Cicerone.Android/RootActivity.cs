using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;

namespace Cicerone.Droid
{
	[Activity(Label = "Cicerone", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class RootActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<Core.App, App>, Core.App, App>
	{
	}
}