using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Staff
{
    [JsonProperty("links")] public Links Links { get; set; }
}