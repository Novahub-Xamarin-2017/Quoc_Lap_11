using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise1.Models
{
    public class TweetPost
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }
    }
}