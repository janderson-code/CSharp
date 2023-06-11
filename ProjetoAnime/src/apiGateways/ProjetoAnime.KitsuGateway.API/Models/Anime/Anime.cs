using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models.Anime;

public class Anime
{
    [JsonProperty("data")]
    public List<AnimeData> Data { get; set; }

    [JsonProperty("meta")]
    public Metadata Meta { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }
}

public class AnimeData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    [JsonProperty("attributes")]
    public AnimeAttributes Attributes { get; set; }

    [JsonProperty("relationships")]
    public AnimeRelationships Relationships { get; set; }
}

public class Links
{
    [JsonProperty("self")]
    public string Self { get; set; }

    [JsonProperty("related")]
    public string Related { get; set; }
}

public class AnimeAttributes
{
    [JsonProperty("createdAt")]
    public string CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public string UpdatedAt { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("synopsis")]
    public string Synopsis { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("coverImageTopOffset")]
    public int CoverImageTopOffset { get; set; }

    [JsonProperty("titles")]
    public AnimeTitles Titles { get; set; }

    [JsonProperty("canonicalTitle")]
    public string CanonicalTitle { get; set; }

    [JsonProperty("abbreviatedTitles")]
    public List<string> AbbreviatedTitles { get; set; }

    [JsonProperty("averageRating")]
    public string AverageRating { get; set; }

    [JsonProperty("ratingFrequencies")]
    public Dictionary<string, string> RatingFrequencies { get; set; }

    [JsonProperty("userCount")]
    public int UserCount { get; set; }

    [JsonProperty("favoritesCount")]
    public int FavoritesCount { get; set; }

    [JsonProperty("startDate")]
    public string StartDate { get; set; }

    [JsonProperty("endDate")]
    public string EndDate { get; set; }

    [JsonProperty("nextRelease")]
    public string NextRelease { get; set; }

    [JsonProperty("popularityRank")]
    public int PopularityRank { get; set; }

    [JsonProperty("ratingRank")]
    public int RatingRank { get; set; }

    [JsonProperty("ageRating")]
    public string AgeRating { get; set; }

    [JsonProperty("ageRatingGuide")]
    public string AgeRatingGuide { get; set; }

    [JsonProperty("subtype")]
    public string Subtype { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("tba")]
    public string Tba { get; set; }

    [JsonProperty("posterImage")]
    public ImageData PosterImage { get; set; }

    [JsonProperty("coverImage")]
    public ImageData CoverImage { get; set; }

    [JsonProperty("episodeCount")]
    public int EpisodeCount { get; set; }

    [JsonProperty("episodeLength")]
    public int EpisodeLength { get; set; }

    [JsonProperty("totalLength")]
    public double TotalLength { get; set; }

    [JsonProperty("youtubeVideoId")]
    public string YoutubeVideoId { get; set; }

    [JsonProperty("showType")]
    public string ShowType { get; set; }

    [JsonProperty("nsfw")]
    public bool Nsfw { get; set; }
}

public class AnimeTitles
{
    [JsonProperty("en")]
    public string English { get; set; }

    [JsonProperty("en_jp")]
    public string EnglishJapanese { get; set; }

    [JsonProperty("ja_jp")]
    public string Japanese { get; set; }
}

public class ImageData
{
    [JsonProperty("tiny")]
    public string Tiny { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }

    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("medium")]
    public string Medium { get; set; }

    [JsonProperty("original")]
    public string Original { get; set; }

    [JsonProperty("meta")]
    public ImageMeta Meta { get; set; }
}

public class ImageMeta
{
    [JsonProperty("dimensions")]
    public ImageDimensions Dimensions { get; set; }
}

public class ImageDimensions
{
    [JsonProperty("tiny")]
    public Dimension Tiny { get; set; }

    [JsonProperty("large")]
    public Dimension Large { get; set; }

    [JsonProperty("small")]
    public Dimension Small { get; set; }

    [JsonProperty("medium")]
    public Dimension Medium { get; set; }
}

public class Dimension
{
    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }
}

public class AnimeRelationships
{
    [JsonProperty("genres")]
    public RelationshipLinks Genres { get; set; }

    [JsonProperty("categories")]
    public RelationshipLinks Categories { get; set; }

    [JsonProperty("castings")]
    public RelationshipLinks Castings { get; set; }

    [JsonProperty("installments")]
    public RelationshipLinks Installments { get; set; }

    [JsonProperty("mappings")]
    public RelationshipLinks Mappings { get; set; }

    [JsonProperty("reviews")]
    public RelationshipLinks Reviews { get; set; }

    [JsonProperty("mediaRelationships")]
    public RelationshipLinks MediaRelationships { get; set; }

    [JsonProperty("characters")]
    public RelationshipLinks Characters { get; set; }

    [JsonProperty("staff")]
    public RelationshipLinks Staff { get; set; }

    [JsonProperty("productions")]
    public RelationshipLinks Productions { get; set; }

    [JsonProperty("quotes")]
    public RelationshipLinks Quotes { get; set; }

    [JsonProperty("episodes")]
    public RelationshipLinks Episodes { get; set; }

    [JsonProperty("streamingLinks")]
    public RelationshipLinks StreamingLinks { get; set; }

    [JsonProperty("animeProductions")]
    public RelationshipLinks AnimeProductions { get; set; }

    [JsonProperty("animeCharacters")]
    public RelationshipLinks AnimeCharacters { get; set; }

    [JsonProperty("animeStaff")]
    public RelationshipLinks AnimeStaff { get; set; }
}

public class RelationshipLinks
{
    [JsonProperty("links")]
    public Links Links { get; set; }
}

public class Metadata
{
    [JsonProperty("count")]
    public int Count { get; set; }
}
