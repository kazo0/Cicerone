﻿using System;
using System.Threading.Tasks;
using Cicerone.Core.Models;

namespace Cicerone.Core.Clients.Untappd
{
	public interface IUntappdClient
	{
		Task<BeerSearchResponse> SearchBeer(string term, int offset = 0);

		Task<BeerDetailsResponse> GetBeerDetails(long beerId);
	}
}
