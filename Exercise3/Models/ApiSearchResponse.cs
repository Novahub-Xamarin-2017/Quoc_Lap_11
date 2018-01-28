using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise3.Models
{
    public class ApiSearchResponse
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }
}