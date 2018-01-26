using System.Collections.Generic;
using System.IO;
using System.Net;
using Android.App;
using Android.Graphics;
using Newtonsoft.Json;

namespace Exercise1.Models
{
    class Ultilities
    {
        public static List<T> GetJsonFromAsset<T>(string fileName)
        {
            using (var stream = Application.Context.Assets.Open(fileName))
            {
                var streamReader = new StreamReader(stream);
                var content = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }
    }
}