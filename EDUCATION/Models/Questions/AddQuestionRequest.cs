using EDUCATION.Entities;
using Newtonsoft.Json;

namespace EDUCATION.Models.Questions
{
    public class AddQuestionRequest
    {
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

        [JsonProperty("rightTestAnswer")]
        public string RightTestAnswer { get; set; }

        [JsonProperty("rightWordAnswer")]
        public string RightWordAnswer { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}
