using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models.Anime;

public class Anime
{
    [JsonProperty("data")] public AnimeData Data { get; set; }

    [JsonProperty("included")] public List<IncludedData> Included { get; set; }
}