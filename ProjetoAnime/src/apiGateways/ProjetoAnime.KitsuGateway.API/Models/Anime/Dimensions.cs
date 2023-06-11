using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Dimensions
{
    [JsonProperty("width")] public int Width { get; set; }

    [JsonProperty("height")] public int Height { get; set; }
}