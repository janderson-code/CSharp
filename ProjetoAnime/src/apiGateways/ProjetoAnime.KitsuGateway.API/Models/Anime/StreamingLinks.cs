using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class StreamingLinks
{
    [JsonProperty("links")] public Links Links { get; set; }
}