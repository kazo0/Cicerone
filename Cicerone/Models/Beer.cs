using System;
using Newtonsoft.Json;

namespace Cicerone.Models
{
    public class Beer
    {
        [JsonProperty("bid")]
        public long Bid { get; set; }

        [JsonProperty("beer_name")]
        public string BeerName { get; set; }

        [JsonProperty("beer_label")]
        public Uri BeerLabel { get; set; }

        [JsonProperty("beer_abv")]
        public double BeerAbv { get; set; }

        [JsonProperty("beer_slug")]
        public string BeerSlug { get; set; }

        [JsonProperty("beer_ibu")]
        public long BeerIbu { get; set; }

        [JsonProperty("beer_description")]
        public string BeerDescription { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("beer_style")]
        public string BeerStyle { get; set; }

        [JsonProperty("in_production")]
        public long InProduction { get; set; }

        [JsonProperty("auth_rating")]
        public long AuthRating { get; set; }

        [JsonProperty("wish_list")]
        public bool WishList { get; set; }
    }
}
