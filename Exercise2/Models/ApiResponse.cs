using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise2.Models
{
    class ApiResponse
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [JsonProperty("items")]
        public List<User> Users { get; set; }
    }
}
