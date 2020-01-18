using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cicerone.Clients.Untappd;
using Cicerone.Models;

namespace Cicerone.Services.Beers
{
	public class BeerService : IBeerService
	{
		private readonly IUntappdClient _untappdClient;

		public BeerService(IUntappdClient untappdClient)
		{
			_untappdClient = untappdClient;
		}

		public async Task<List<Beer>> SearchBeer(string searchTerm)
		{
			var searchResponse = await _untappdClient.SearchBeer(searchTerm);

			return searchResponse?.Beers
				?.BeerItems
				?.Select(x => x.Beer)
				.ToList() ?? new List<Beer>();
		}
	}
}
