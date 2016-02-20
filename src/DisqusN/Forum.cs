using Newtonsoft.Json;

namespace DisqusN
{
    public class Forum
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public long Founder { get; set; }
        public string TwitterName { get; set; }
        public string Url { get; set; }
        [JsonProperty("raw_description")]
        public string RawDescription { get; set; }
        public string Guidelines { get; set; }
        public Favicon Favicon { get; set; }
        public string Language { get; set; }
        public int DaysThreadAlive { get; set; }
        public Avatar Avatar { get; set; }
        public string SignedUrl { get; set; }
        public int DaysAlive { get; set; }
        public long Pk { get; set; }
        [JsonProperty("raw_guidelines")]
        public string RawGuidelines { get; set; }
        public ForumSettings Settings { get; set; }
        public string Id { get; set; }
        public string Channel { get; set; }
        public string Name { get; set; }
    }
}
