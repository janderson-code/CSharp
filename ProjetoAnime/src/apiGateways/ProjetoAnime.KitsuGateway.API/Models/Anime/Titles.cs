using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Titles
{
    [JsonProperty("en")] public string En { get; set; }

    [JsonProperty("en_jp")] public string En_jp { get; set; }

    [JsonProperty("ja_jp")] public string Ja_jp { get; set; }
}