using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Demo
{
    [Headers("Content-Type: application/json")]
    public interface ITweetApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> Login([Body] object user);

        [Get("/tweets")]
        Task<List<TweetPost>> GetPosts();

        [Delete("/logout")]
        Task<HttpResponseMessage> Logout([Body] object user);
    }
}