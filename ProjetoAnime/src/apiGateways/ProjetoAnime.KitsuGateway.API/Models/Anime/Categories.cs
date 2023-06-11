using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Categories
{
    [JsonProperty("links")] public Links Links { get; set; }
}