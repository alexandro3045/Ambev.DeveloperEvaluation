using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models
{
    public class BadRequestModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("errors")]
        public Dictionary<string, string[]> Errors { get; set; }
    }
}