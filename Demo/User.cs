using Newtonsoft.Json;

namespace Demo
{
    public class User
    {
        [JsonProperty("login")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string PassWord { get; set; }

        public User(string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
        }
    }
}