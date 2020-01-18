using System;
using System.Threading.Tasks;
using Cicerone.Models;
using RestSharp;

namespace Cicerone.Clients
{
	public interface IUntappdClient
	{
		Task<BeerSearchResponse> SearchBeer(string term);
	}

	public class UntappdClient : BaseApiClient, IUntappdClient
	{
		protected override string BaseUrl => "https://api.untappd.com/v4";

		public UntappdClient(IRestClient client) : base(client)
		{
		}

		public async Task<BeerSearchResponse> SearchBeer(string term)
		{
			var request = new RestRequest("/search/beer", Method.GET);
			request.AddQueryParameter("q", term, encode: true);

			return await Get<BeerSearchResponse>(request);
		}
	}
}
