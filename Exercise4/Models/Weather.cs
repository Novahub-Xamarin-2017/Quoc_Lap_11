using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class Weather
    {
        [JsonProperty("weather")]
        public List<WeatherDetail> WeatherDetail { get; set; }

        [JsonProperty("main")]
        public Temperature Temperature { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}