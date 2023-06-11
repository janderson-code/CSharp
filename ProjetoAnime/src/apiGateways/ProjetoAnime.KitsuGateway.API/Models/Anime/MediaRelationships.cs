using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class MediaRelationships
{
    [JsonProperty("links")] public Links Links { get; set; }
}