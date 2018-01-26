using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Exercise1.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise1.Controllers
{
    class TweetController
    {
        public const string RootUrl = "https://salty-mesa-4348.herokuapp.com/";

        public string Cookie { get; set; }

        private readonly RestClient client = new RestClient(RootUrl);

        private static TweetController instance;

        private TweetController()
        {
        }

        public static TweetController Instance => instance ?? (instance = new TweetController());

        public void Login(string username, string pass)
        {
            var request = new RestRequest("login", Method.POST) {RequestFormat = DataFormat.Json};
            request.AddBody(new {login = username, password = pass});
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized) throw new Exception("Wrong username/password");
            Cookie = response.Headers.Single(h => h.Name.Equals("Set-Cookie")).Value.ToString().Split(';').First();
        }

        public List<TweetPost> GetPosts()
        {
            var request = new RestRequest("tweets", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddCookie(Cookie.Split('=')[0], Cookie.Split('=')[1]);
            var posts = JsonConvert.DeserializeObject<List<TweetPost>>(client.Execute(request).Content);
            return posts;
        }

        public void Logout()
        {
            var request = new RestRequest("tweets", Method.GET);
            request.AddCookie(Cookie.Split('=')[0], Cookie.Split('=')[1]);
            client.Execute(request);
            Cookie = null;
        }
    }
}