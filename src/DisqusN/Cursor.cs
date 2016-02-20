using LanguageExt;
using Newtonsoft.Json;

namespace DisqusN
{
    public class Cursor
    {
        [JsonProperty("prev", NullValueHandling = NullValueHandling.Ignore)]
        public Option<string> Previous { get; set; }
        [JsonProperty("hasNext")]
        public bool HasNext { get; set; }
        [JsonProperty("hasPrev")]
        public bool HasPrevious { get; set; }
        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        public Option<string> Next { get; set; }
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public Option<int> Total { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("more")]
        public bool More { get; set; }
    }
}
