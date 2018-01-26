using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class Temperature
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
    }
}