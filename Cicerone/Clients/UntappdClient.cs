using System;
using RestSharp;

namespace Cicerone.Clients
{
	public interface IUntappdClient
	{

	}

	public class UntappdClient : BaseApiClient, IUntappdClient
	{
		protected override string BaseUrl => "https://api.untappd.com/v4";

		public UntappdClient(IRestClient client) : base(client)
		{
		}

	}
}
