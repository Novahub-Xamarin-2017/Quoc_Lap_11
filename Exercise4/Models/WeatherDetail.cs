using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class WeatherDetail
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}