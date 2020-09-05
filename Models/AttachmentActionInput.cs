using Newtonsoft.Json;
namespace SparkDotNet
{
    public class AttachmentActionInput : WebexObject
    {

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("tel")]
        public string Tel { get; set; }
    }
}