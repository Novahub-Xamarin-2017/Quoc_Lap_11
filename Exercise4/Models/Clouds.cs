using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long Cloudliness { get; set; }
    }
}