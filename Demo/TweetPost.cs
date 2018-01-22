using System.Collections.Generic;
using Newtonsoft.Json;

namespace Demo
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

        public override string ToString()
        {
            return Author + "\n" + Content + "\n";
        }
    }
}