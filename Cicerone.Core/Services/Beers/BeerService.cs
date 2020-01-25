using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cicerone.Core.Clients.Untappd;
using Cicerone.Core.Models;

namespace Cicerone.Core.Services.Beers
{
	public class BeerService : IBeerService
	{
		private readonly IUntappdClient _untappdClient;

		public BeerService(IUntappdClient untappdClient)
		{
			_untappdClient = untappdClient;
		}

		public async Task<BeerDetail> GetBeerDetails(long beerId)
		{
			var beerResponse = await _untappdClient.GetBeerDetails(beerId);

			return beerResponse?.Beer;
		}

		public async Task<BeerSearchResponse> GetBeers(string searchTerm, int offset = 0)
		{
			var searchResponse = await _untappdClient.SearchBeer(searchTerm, offset);

			return searchResponse;
		}
	}
}
