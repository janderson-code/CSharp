using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Meta
{
    [JsonProperty("tiny")] public Dimensions Tiny { get; set; }

    [JsonProperty("large")] public Dimensions Large { get; set; }

    [JsonProperty("small")] public Dimensions Small { get; set; }

    [JsonProperty("medium")] public Dimensions Medium { get; set; }
}