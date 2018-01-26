using Exercise6.Models;
using Exercise6.Utils;
using RestSharp;

namespace Exercise6.Controllers
{
    class VietcombankApiController
    {
        private const string Url = "https://www.vietcombank.com.vn/exchangerates/ExrateXML.aspx";

        private readonly RestClient client = new RestClient(Url);

        public ExrateList GetExrateData()
        {
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return XmlSerializerUtil.DesirializeObject<ExrateList>(response.Content);
        }
    }
}