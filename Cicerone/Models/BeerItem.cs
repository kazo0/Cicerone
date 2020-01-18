using System;
using Newtonsoft.Json;

namespace Cicerone.Models
{
    public class BeerItem
    {
        [JsonProperty("checkin_count")]
        public long CheckinCount { get; set; }

        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }
    }
}
