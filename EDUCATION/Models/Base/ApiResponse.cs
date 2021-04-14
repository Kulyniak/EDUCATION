using Newtonsoft.Json;

namespace EDUCATION.Models.Base
{
    public class ApiResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; } = true;

        [JsonProperty("message")]
        public string Message { get; set; } = "";

        //private string _testProp;
        //public string TestProp
        //{
        //    get => _testProp;
        //    set
        //    {
        //        this._testProp = value;
        //    }
        //}
    }
}
