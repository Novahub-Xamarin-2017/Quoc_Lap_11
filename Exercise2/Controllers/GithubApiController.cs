using System.Collections.Generic;
using Exercise2.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise2.Controllers
{
    class GithubApiController
    {
        private static GithubApiController instance;

        private const string Url = "https://api.github.com";

        private readonly RestClient client = new RestClient(Url);

        private GithubApiController()
        {
        }

        public static GithubApiController Instance => instance ?? (instance = new GithubApiController());

        public List<User> SearchUser(string userName)
        {
            var request = new RestRequest($"search/users?q={userName}", Method.GET);
            var response = JsonConvert.DeserializeObject<ApiResponse>(client.Execute(request).Content);
            return response.Users;
        }

        public User GetUserDetail(string userName)
        {
            var request = new RestRequest($"users/{userName}", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<User>(response.Content);
        }

        public List<Repository> GetUseRepositories(string userName)
        {
            var request = new RestRequest($"users/{userName}/repos", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Repository>>(response.Content);
        }
    }
}
