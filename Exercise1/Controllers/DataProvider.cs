using System.Collections.Generic;
using Exercise1.Models;

namespace Exercise1.Controllers
{
    class DataProvider
    {
        public List<TweetPost> Posts { get; set; }

        private static DataProvider instance;

        public static DataProvider Instance => instance ?? (instance = new DataProvider());

        private DataProvider()
        {
        }
    }
}