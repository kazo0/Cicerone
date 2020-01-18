using System;
using Newtonsoft.Json;

namespace Cicerone.Core.Models
{
    public class BeerSearchResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("time_taken")]
        public double TimeTaken { get; set; }

        [JsonProperty("brewery_id")]
        public long BreweryId { get; set; }

        [JsonProperty("search_type")]
        public string SearchType { get; set; }

        [JsonProperty("type_id")]
        public long TypeId { get; set; }

        [JsonProperty("search_version")]
        public long SearchVersion { get; set; }

        [JsonProperty("found")]
        public long Found { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("parsed_term")]
        public string ParsedTerm { get; set; }

        [JsonProperty("beers")]
        public Beers Beers { get; set; }
    }
}
