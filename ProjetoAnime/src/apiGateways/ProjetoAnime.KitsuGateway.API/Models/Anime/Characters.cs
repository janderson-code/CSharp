using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Characters
{
    [JsonProperty("links")] public Links Links { get; set; }
}