using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Cicerone.Core.Clients
{
	public abstract class BaseApiClient
	{
		protected IRestClient Client { get; }
		protected virtual string BaseUrl { get; }

		public BaseApiClient(IRestClient client)
		{
			Client = client;

			Client.BaseUrl = new Uri(BaseUrl);
			Client.UseSerializer<JsonDeserializer>();
		}

		protected async Task<T> Get<T>(RestRequest request) where T : class
		{
			var response = await Client.ExecuteGetAsync(request);

			if (response.StatusCode != HttpStatusCode.OK)
			{
				Console.WriteLine($"HTTP Error: {response.StatusDescription}");
				return default;
			}

			try
			{
				return JsonConvert.DeserializeObject<T>(response.Content);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error occurred when deserializing response: {e.Message}");
			}

			return null;
		}
	}
}
