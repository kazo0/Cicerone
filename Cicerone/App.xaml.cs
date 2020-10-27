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
			Startup.Init();
			MainPage = new NavigationPage(Startup.ServiceProvider.GetService<SearchPage>());
		}
	}
}
