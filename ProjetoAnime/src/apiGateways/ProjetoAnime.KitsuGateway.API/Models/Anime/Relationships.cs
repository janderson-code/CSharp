using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class Relationships
{
    [JsonProperty("genres")] public Genres Genres { get; set; }

    [JsonProperty("categories")] public Categories Categories { get; set; }

    [JsonProperty("castings")] public Castings Castings { get; set; }

    [JsonProperty("installments")] public Installments Installments { get; set; }

    [JsonProperty("mappings")] public Mappings Mappings { get; set; }

    [JsonProperty("reviews")] public Reviews Reviews { get; set; }

    [JsonProperty("mediaRelationships")] public MediaRelationships MediaRelationships { get; set; }

    [JsonProperty("characters")] public Characters Characters { get; set; }

    [JsonProperty("staff")] public Staff Staff { get; set; }

    [JsonProperty("productions")] public Productions Productions { get; set; }

    [JsonProperty("quotes")] public Quotes Quotes { get; set; }

    [JsonProperty("episodes")] public Episodes Episodes { get; set; }

    [JsonProperty("streamingLinks")] public StreamingLinks StreamingLinks { get; set; }
}