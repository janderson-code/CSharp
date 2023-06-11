using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class CoverImage
{
    [JsonProperty("tiny")] public string Tiny { get; set; }

    [JsonProperty("large")] public string Large { get; set; }

    [JsonProperty("small")] public string Small { get; set; }

    [JsonProperty("original")] public string Original { get; set; }

    [JsonProperty("meta")] public Meta Meta { get; set; }
}