using Newtonsoft.Json;

namespace EDUCATION.Models.Base
{
    public class ApiResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; } = true;

        [JsonProperty("message")]
        public string Message { get; set; } = "";
    }
}
