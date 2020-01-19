using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cicerone.Core.Models;
using Cicerone.Core.Services.Beers;
using MvvmCross.Commands;

namespace Cicerone.Core.ViewModels
{
	public class BeerDetailsViewModel : BaseViewModel<long>
	{
		private readonly IBeerService _beerService;
		private long _beerId;

		private ICommand _refreshCommand;
		public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(FetchBeer));

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
	}
}
