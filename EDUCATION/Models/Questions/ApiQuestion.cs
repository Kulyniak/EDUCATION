﻿using EDUCATION.Entities;
using Newtonsoft.Json;

namespace EDUCATION.Models.Questions
{
    public class ApiQuestion
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public QuestionType Type { get; set; }

        [JsonProperty("level")]
        public UserLevel Level { get; set; }

        [JsonProperty("testAnswer1")]
        public string TestAnswer1 { get; set; }

        [JsonProperty("testAnswer2")]
        public string TestAnswer2 { get; set; }

        [JsonProperty("testAnswer3")]
        public string TestAnswer3 { get; set; }

        [JsonProperty("testAnswer4")]
        public string TestAnswer4 { get; set; }
    }
}
