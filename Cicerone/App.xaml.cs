using System;
using Cicerone.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cicerone
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new SearchPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
