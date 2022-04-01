using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UrlCreation.Models.Url
{
    public class GetUrl
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("long_url")]
        public string LongUrl { get; set; }
    }
}
