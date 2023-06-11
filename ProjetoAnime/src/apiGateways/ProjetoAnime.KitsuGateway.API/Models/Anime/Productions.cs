using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Productions
{
    [JsonProperty("links")] public Links Links { get; set; }
}