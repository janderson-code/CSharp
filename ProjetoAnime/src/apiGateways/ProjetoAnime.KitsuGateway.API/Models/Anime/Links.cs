using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Links
{
    [JsonProperty("self")] public string Self { get; set; }
}