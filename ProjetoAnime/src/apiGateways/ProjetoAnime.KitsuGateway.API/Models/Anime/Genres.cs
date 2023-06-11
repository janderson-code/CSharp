using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Genres
{
    [JsonProperty("links")] public Links Links { get; set; }
}