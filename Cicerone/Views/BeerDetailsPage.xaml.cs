using Cicerone.Core.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cicerone.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BeerDetailsPage : ContentPage
	{
		public BeerDetailsPage(long beerId)
		{
			InitializeComponent();
			var vm = Startup.ServiceProvider.GetService<BeerDetailsViewModel>();
			vm.BeerId = beerId;
			
			BindingContext = vm;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MainThread.BeginInvokeOnMainThread(() => ((BaseViewModel)BindingContext).Initialize());
		}
	}
}
