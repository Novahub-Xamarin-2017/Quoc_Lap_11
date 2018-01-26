using Exercise5.Models;
using Exercise5.Utils;
using RestSharp;

namespace Exercise5.Controllers
{
    class ApiController
    {
        private const string Url = "http://www.sjc.com.vn/xml/tygiavang.xml";

        private readonly RestClient client = new RestClient(Url);

        public ApiResponse GetGoldRates()
        {
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return XmlSerializerUtil.DesirializeObject<ApiResponse>(response.Content);
        }
    }
}