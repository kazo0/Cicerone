using System;
using Newtonsoft.Json;

namespace Cicerone.Models
{
    public class Brewery
    {
        [JsonProperty("brewery_id")]
        public long BreweryId { get; set; }

        [JsonProperty("brewery_name")]
        public string BreweryName { get; set; }

        [JsonProperty("brewery_slug")]
        public string BrewerySlug { get; set; }

        [JsonProperty("brewery_page_url")]
        public string BreweryPageUrl { get; set; }

        [JsonProperty("brewery_type")]
        public string BreweryType { get; set; }

        [JsonProperty("brewery_label")]
        public Uri BreweryLabel { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("brewery_active")]
        public long BreweryActive { get; set; }
    }
}
