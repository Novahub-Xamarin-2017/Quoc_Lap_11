using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}