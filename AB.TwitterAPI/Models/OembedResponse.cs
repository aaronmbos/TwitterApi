using Newtonsoft.Json;

namespace AB.TwitterAPI.Models
{
    public class OembedResponse : ModelBase
    {
        public string Url { get; set; }
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }
        public string Html { get; set; }
    }
}