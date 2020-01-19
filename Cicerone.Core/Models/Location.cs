using System;
using Newtonsoft.Json;

namespace Cicerone.Core.Models
{
    public class Location
    {
        [JsonProperty("brewery_city")]
        public string City { get; set; }

        [JsonProperty("brewery_state")]
        public string State { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }
}
