using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cicerone.Core.Models;
using Cicerone.Core.Services.Beers;
using MvvmCross.Commands;
using Xamarin.Essentials;

namespace Cicerone.Core.ViewModels
{
	public class BeerDetailsViewModel : BaseViewModel<long>
	{
		private readonly IBeerService _beerService;
		private long _beerId;
		private const string TwitterUrl = "https://www.twitter.com";

		private ICommand _refreshCommand;
		public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(FetchBeer));

		private ICommand _navToExternalCommand;
		public ICommand NavToExternalCommand => _navToExternalCommand ?? (_navToExternalCommand = new MvxAsyncCommand<string>(NavigateExternal));

		private ICommand _navToTwitterCommand;
		public ICommand NavToTwitterCommand => _navToTwitterCommand ?? (_navToTwitterCommand = new MvxAsyncCommand<string>(NavToTwitter));

		private BeerDetail _beer;
		public BeerDetail Beer
		{
			get => _beer;
			set => SetProperty(ref _beer, value);
		}

		public BeerDetailsViewModel(IBeerService beerService)
		{
			_beerService = beerService;
		}

		public override void Prepare(long parameter)
		{
			_beerId = parameter;
		}

		public override async Task Initialize()
		{
			await FetchBeer();
		}

		private async Task FetchBeer()
		{
			IsBusy = true;
			Beer = await _beerService.GetBeerDetails(_beerId);
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
