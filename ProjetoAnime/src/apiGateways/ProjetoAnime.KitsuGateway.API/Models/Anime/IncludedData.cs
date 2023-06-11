using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class IncludedData
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("attributes")] public IncludedAttributes Attributes { get; set; }
}