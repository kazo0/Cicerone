using System;
using System.Collections.Generic;
using Cicerone.Core.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cicerone.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
		public SearchPage()
		{
			InitializeComponent();
			var vm = Startup.ServiceProvider.GetService<SearchViewModel>();
			BindingContext = vm;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MainThread.BeginInvokeOnMainThread(() => ((BaseViewModel)BindingContext).Initialize());

			MessagingCenter.Subscribe<SearchViewModel, long>(this, "Navigate", (sender, bid) => Navigation.PushAsync(new BeerDetailsPage(bid)));
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			MessagingCenter.Unsubscribe<SearchViewModel, long>(this, "Navigate");
		}
	}
}
