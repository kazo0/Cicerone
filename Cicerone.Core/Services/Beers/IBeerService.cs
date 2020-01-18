using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cicerone.Core.Models;

namespace Cicerone.Core.Services.Beers
{
	public interface IBeerService
	{
		Task<List<BeerSummary>> GetBeers(string searchTerm);

		Task<BeerDetail> GetBeerDetails(long beerId);
	}
}
