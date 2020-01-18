using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cicerone.Core.Models
{
    public partial class Beers
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("items")]
        public List<BeerItem> BeerItems { get; set; }
    }
}
