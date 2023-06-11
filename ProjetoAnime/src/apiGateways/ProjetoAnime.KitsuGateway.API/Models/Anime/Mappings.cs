using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Mappings
{
    [JsonProperty("links")] public Links Links { get; set; }
}