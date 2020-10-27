using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cicerone.Core.Models;
using Cicerone.Core.Services.Beers;
using MvvmHelpers.Commands;
using Xamarin.Essentials;

namespace Cicerone.Core.ViewModels
{
	public class BeerDetailsViewModel : BaseViewModel
	{
		private readonly IBeerService _beerService;
		private const string TwitterUrl = "https://www.twitter.com";

		private ICommand _refreshCommand;
		public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new AsyncCommand(FetchBeer));

		private ICommand _navToExternalCommand;
		public ICommand NavToExternalCommand => _navToExternalCommand ?? (_navToExternalCommand = new AsyncCommand<string>(NavigateExternal));

		private ICommand _navToTwitterCommand;
		public ICommand NavToTwitterCommand => _navToTwitterCommand ?? (_navToTwitterCommand = new AsyncCommand<string>(NavToTwitter));

		public BeerDetail Beer { get; set; }
		public long BeerId { get; set; }

		public BeerDetailsViewModel(IBeerService beerService)
		{
			_beerService = beerService;
		}

		public override async Task Initialize()
		{
			await FetchBeer();
		}

		private async Task FetchBeer()
		{
			IsBusy = true;
			Beer = await _beerService.GetBeerDetails(BeerId);
			IsBusy = false;
		}

		private async Task NavToTwitter(string handle)
		{
			if (string.IsNullOrWhiteSpace(handle))
			{
				return;
			}

			await NavigateExternal($"{TwitterUrl}/{handle}");
		}

		private async Task NavigateExternal(string uri)
		{
			if (string.IsNullOrWhiteSpace(uri))
			{
				return;
			}

			if (!await Launcher.TryOpenAsync(uri))
			{
				await Browser.OpenAsync(uri);
			}
		}
	}
}
