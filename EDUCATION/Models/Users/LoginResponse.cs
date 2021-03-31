using EDUCATION.Entities;
using EDUCATION.Models.Base;
using Newtonsoft.Json;

namespace EDUCATION.Models.Users
{
    public class LoginResponse : ApiResponse
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("userLevel")]
        public UserLevel UserLevel { get; set; }

        [JsonProperty("role")]
        public UserRole Role { get; set; }
    }
}
