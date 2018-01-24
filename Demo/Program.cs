using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;
using RestSharp;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://salty-mesa-4348.herokuapp.com";
            //Login(url);

            var client = new RestClient(url);
            var request = new RestRequest("login", Method.POST) {RequestFormat = DataFormat.Json};
            request.AddBody(CreateUserObject());
            var res = client.Execute(request);
            
            var cookies = res.Headers.Single(h => h.Name.Equals("Set-Cookie")).Value.ToString().Split(';').First().Split('=');
            var r = new RestRequest("tweets", Method.GET) {RequestFormat = DataFormat.Json};
            
            r.AddHeader("Accept", "application/json");
            r.AddHeader("Content-Type", "application/json");
            
            r.AddCookie(cookies[0], cookies[1]);

            var result = client.Execute(r);
            var posts = JsonConvert.DeserializeObject<List<TweetPost>>(result.Content);
            Console.ReadKey();
        }



        private static async void Login(string url)
        {
            var tweetApi = RestService.For<ITweetApi>(url);
            var response = await tweetApi.Login(CreateUserObject());
            if (!response.IsSuccessStatusCode) return;
            var cookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault();
            Console.WriteLine(cookie);
        }

        private static object CreateUserObject() =>
            new
            {
                login = "foo",
                password = "bar"
            };
    }
}
