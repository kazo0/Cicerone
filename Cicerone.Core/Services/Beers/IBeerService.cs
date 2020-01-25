using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cicerone.Core.Models;

namespace Cicerone.Core.Services.Beers
{
	public interface IBeerService
	{
		Task<BeerSearchResponse> GetBeers(string searchTerm, int offset = 0);

		Task<BeerDetail> GetBeerDetails(long beerId);
	}
}
