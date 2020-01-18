using System;
using System.Threading.Tasks;
using Cicerone.Models;
using RestSharp;
using RestSharp.Authenticators;
using Xamarin.Essentials;

namespace Cicerone.Clients.Untappd
{
	public class UntappdClient : BaseApiClient, IUntappdClient
	{
		protected override string BaseUrl => Constants.BaseUrl;

		public UntappdClient(IRestClient client) : base(client)
		{
			Client.Authenticator = new SimpleAuthenticator(
				"client_id",
				Constants.ClientId,
				"client_secret",
				Constants.ClientSecret);

			Client.UserAgent = $"Cicerone {DeviceInfo.Platform} ({Constants.ClientId})";
		}

		public async Task<BeerSearchResponse> SearchBeer(string term)
		{
			var request = new RestRequest("/search/beer", Method.GET);
			request.AddQueryParameter("q", term, encode: true);

			var response = await Get<BaseResponse<BeerSearchResponse>>(request);
			return response?.Response;
		}
	}
}
