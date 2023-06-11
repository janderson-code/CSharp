using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Reviews
{
    [JsonProperty("links")] public Links Links { get; set; }
}