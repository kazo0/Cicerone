using System;
using Newtonsoft.Json;

namespace Cicerone.Core.Models
{
    public class Contact
    {
        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
