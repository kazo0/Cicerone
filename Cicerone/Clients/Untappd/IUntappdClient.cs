using System;
using System.Threading.Tasks;
using Cicerone.Models;

namespace Cicerone.Clients.Untappd
{
	public interface IUntappdClient
	{
		Task<BeerSearchResponse> SearchBeer(string term);
	}
}
