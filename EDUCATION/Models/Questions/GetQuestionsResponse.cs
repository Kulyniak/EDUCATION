using EDUCATION.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUCATION.Models.Questions
{
    public class GetQuestionsResponse : ApiResponse
    {
        [JsonProperty("questions")]
        public List<ApiQuestion> Questions { get; set; }
    }
}
