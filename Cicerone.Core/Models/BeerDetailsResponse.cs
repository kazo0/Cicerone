using System;
using Newtonsoft.Json;

namespace Cicerone.Core.Models
{
	public class BeerDetailsResponse
	{
		[JsonProperty("beer")]
		public BeerDetail Beer { get; set; }
	}
}
