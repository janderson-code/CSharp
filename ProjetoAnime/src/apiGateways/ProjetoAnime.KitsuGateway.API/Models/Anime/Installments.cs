using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Installments
{
    [JsonProperty("links")] public Links Links { get; set; }
}