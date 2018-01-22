using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://salty-mesa-4348.herokuapp.com";
            Login(url);
            Console.ReadKey();
        }



        private static async void Login(string url)
        {
            var tweetApi = RestService.For<ITweetApi>(url);
            var response = await tweetApi.Login(CreateUserObject());
            if (!response.IsSuccessStatusCode) return;
            var cookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault();
            Console.WriteLine(cookie);

            var posts = await tweetApi.GetPosts();

            var res = await tweetApi.Logout(CreateUserObject());
        }

        private static object CreateUserObject() =>
            new
            {
                login = "foo",
                password = "bar"
            };
    }
}
