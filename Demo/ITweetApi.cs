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
        Task<List<TweetPost>> GetPosts([Header("cookie")] string cookie);

        [Delete("/logout")]
        Task<HttpResponseMessage> Logout([Body] object user);
    }
}