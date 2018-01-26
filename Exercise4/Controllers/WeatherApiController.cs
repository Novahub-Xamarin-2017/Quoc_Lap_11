using Exercise4.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise4.Controllers
{
    class WeatherApiController
    {
        private const string Url = "http://api.openweathermap.org/data/2.5";

        private const string Api = "18130b308759be027c247e699d7a0c66";

        private readonly RestClient client = new RestClient(Url);

        public Weather GetWeatherInfo(string cityName)
        {
            var request = new RestRequest($"weather?q={cityName}&APPID={Api}&units=metric", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Weather>(response.Content);
        }
    }
}