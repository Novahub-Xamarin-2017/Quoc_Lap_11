using System.Collections.Generic;
using Exercise3.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise3.Controllers
{
    class GettyImageApiController
    {
        private const string Url = "https://api.gettyimages.com/v3";

        private const string ApiKey = "bfpwsgt354utxfynpum3hhgm";

        private readonly RestClient client = new RestClient(Url);

        public List<Image> SearchImage(string keyword)
        {
            var request = new RestRequest($"search/images?phrase={keyword}", Method.GET);
            request.AddHeader("Api-key", ApiKey);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ApiSearchResponse>(response.Content).Images;
        }
    }
}