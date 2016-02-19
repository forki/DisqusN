using System;
using System.Collections.Generic;
using LanguageExt;
using Newtonsoft.Json;

namespace DisqusN.Core.Resources.Forums
{
    public class Thread
    {
        public string Feed { get; set; }
        public string Forum { get; set; }
        public List<string> Identifiers { get; set; }
        public int Dislikes { get; set; }
        public int Likes { get; set; }
        public string Message { get; set; }
        public bool IsSpam { get; set; }
        public bool IsDeleted { get; set; }
        public string Category { get; set; }
        [JsonProperty("clean_title")]
        public string CleanTitle { get; set; }
        public int UserScore { get; set; }
        public long Id { get; set; }
        public string SignedLink { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonProperty("raw_message")]
        public string RawMessage { get; set; }
        public bool IsClosed { get; set; }
        public string Link { get; set; }
        public string Slug { get; set; }
        [JsonConverter(typeof(AuthorConverter))]
        public Either<long, Author> Author { get; set; }
        public long Posts { get; set; }
        public bool UserSubscription { get; set; }
        public string Title { get; set; }
        public long? HighlightedPost { get; set; }
    }
}
