using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class AnimeData
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("attributes")] public Attributes Attributes { get; set; }

    [JsonProperty("relationships")] public Relationships Relationships { get; set; }
}