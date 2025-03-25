using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models
{
    public class BadRequestModel
    {
        [JsonProperty("succes")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public Errors[] Errors { get; set; }
    }

    public class Errors
    {
        public string Error { get; set; }
        public string Detail { get; set; }
    }
}