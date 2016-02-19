using System;

namespace DisqusN.Core
{
    public class Author 
    {
        public string UserName { get; set; }
        public string About { get; set; }
        public string Name { get; set; }
        public bool Disable3rdPartyTrackers { get; set; }
        public string Url { get; set; }
        public DateTime JoinedAt { get; set; }
        public string ProfileUrl { get; set; }
        public bool IsPowerContributor { get; set; }
        public string Location { get; set; }
        public bool IsPrivate { get; set; }
        public string SignedUrl { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsAnonymous { get; set; }
        public long Id { get; set; }
        public Avatar Avatar { get; set; }
    }
}
