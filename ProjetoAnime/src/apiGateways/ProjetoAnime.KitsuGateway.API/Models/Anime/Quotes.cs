using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Quotes
{
    [JsonProperty("links")] public Links Links { get; set; }
}