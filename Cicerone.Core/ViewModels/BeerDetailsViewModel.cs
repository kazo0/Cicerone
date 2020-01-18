using System;
using System.Threading.Tasks;
using Cicerone.Core.Models;
using Cicerone.Core.Services.Beers;

namespace Cicerone.Core.ViewModels
{
	public class BeerDetailsViewModel : BaseViewModel<long>
	{
		private readonly IBeerService _beerService;
		private long _beerId;

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
			Beer = await _beerService.GetBeerDetails(_beerId);
		}
	}
}
