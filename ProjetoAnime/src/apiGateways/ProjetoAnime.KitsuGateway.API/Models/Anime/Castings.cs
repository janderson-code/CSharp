using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Castings
{
    [JsonProperty("links")] public Links Links { get; set; }
}