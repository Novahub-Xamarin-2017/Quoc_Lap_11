﻿using Newtonsoft.Json;

namespace Exercise3.Models
{
    public class MaxDimensions
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}