using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models.Manga;

public class MangaResponse
{
    [JsonProperty("data")]
    public MangaData Data { get; set; }
}

public class MangaData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    [JsonProperty("attributes")]
    public MangaAttributes Attributes { get; set; }

    [JsonProperty("relationships")]
    public MangaRelationships Relationships { get; set; }
}

public class MangaAttributes
{
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("synopsis")]
    public string Synopsis { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("coverImageTopOffset")]
    public int CoverImageTopOffset { get; set; }

    [JsonProperty("titles")]
    public MangaTitles Titles { get; set; }

    [JsonProperty("canonicalTitle")]
    public string CanonicalTitle { get; set; }

    [JsonProperty("abbreviatedTitles")]
    public List<string> AbbreviatedTitles { get; set; }

    [JsonProperty("averageRating")]
    public string AverageRating { get; set; }

    [JsonProperty("ratingFrequencies")]
    public RatingFrequencies RatingFrequencies { get; set; }

    [JsonProperty("userCount")]
    public int UserCount { get; set; }

    [JsonProperty("favoritesCount")]
    public int FavoritesCount { get; set; }

    [JsonProperty("startDate")]
    public DateTime StartDate { get; set; }

    [JsonProperty("endDate")]
    public DateTime? EndDate { get; set; }

    [JsonProperty("nextRelease")]
    public DateTime? NextRelease { get; set; }

    [JsonProperty("popularityRank")]
    public int PopularityRank { get; set; }

    [JsonProperty("ratingRank")]
    public int? RatingRank { get; set; }

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
    public PosterImage PosterImage { get; set; }

    [JsonProperty("coverImage")]
    public object CoverImage { get; set; }

    [JsonProperty("chapterCount")]
    public object ChapterCount { get; set; }

    [JsonProperty("volumeCount")]
    public int? VolumeCount { get; set; }

    [JsonProperty("serialization")]
    public string Serialization { get; set; }

    [JsonProperty("mangaType")]
    public string MangaType { get; set; }
}

public class MangaTitles
{
    [JsonProperty("en")]
    public string En { get; set; }

    [JsonProperty("en_jp")]
    public string EnJp { get; set; }

    [JsonProperty("ja_jp")]
    public string JaJp { get; set; }
}

public class MangaRelationships
{
    [JsonProperty("genres")]
    public Links Genres { get; set; }

    [JsonProperty("categories")]
    public Links Categories { get; set; }

    [JsonProperty("castings")]
    public Links Castings { get; set; }

    [JsonProperty("installments")]
    public Links Installments { get; set; }

    [JsonProperty("mappings")]
    public Links Mappings { get; set; }

    [JsonProperty("reviews")]
    public Links Reviews { get; set; }

    [JsonProperty("mediaRelationships")]
    public Links MediaRelationships { get; set; }

    [JsonProperty("characters")]
    public Links Characters { get; set; }

    [JsonProperty("staff")]
    public Links Staff { get; set; }

    [JsonProperty("productions")]
    public Links Productions { get; set; }

    [JsonProperty("quotes")]
    public Links Quotes { get; set; }

    [JsonProperty("chapters")]
    public Links Chapters { get; set; }

    [JsonProperty("mangaCharacters")]
    public Links MangaCharacters { get; set; }

    [JsonProperty("mangaStaff")]
    public Links MangaStaff { get; set; }
}

public class Links
{
    [JsonProperty("self")]
    public string Self { get; set; }

    [JsonProperty("related")]
    public string Related { get; set; }
}

public class RatingFrequencies
{
    [JsonProperty("2")]
    public string Rating2 { get; set; }

    [JsonProperty("3")]
    public string Rating3 { get; set; }

    [JsonProperty("4")]
    public string Rating4 { get; set; }

    [JsonProperty("5")]
    public string Rating5 { get; set; }

    [JsonProperty("6")]
    public string Rating6 { get; set; }

    [JsonProperty("7")]
    public string Rating7 { get; set; }

    [JsonProperty("8")]
    public string Rating8 { get; set; }

    [JsonProperty("9")]
    public string Rating9 { get; set; }

    [JsonProperty("10")]
    public string Rating10 { get; set; }

    [JsonProperty("11")]
    public string Rating11 { get; set; }

    [JsonProperty("12")]
    public string Rating12 { get; set; }

    [JsonProperty("13")]
    public string Rating13 { get; set; }

    [JsonProperty("14")]
    public string Rating14 { get; set; }

    [JsonProperty("15")]
    public string Rating15 { get; set; }

    [JsonProperty("16")]
    public string Rating16 { get; set; }

    [JsonProperty("17")]
    public string Rating17 { get; set; }

    [JsonProperty("18")]
    public string Rating18 { get; set; }

    [JsonProperty("19")]
    public string Rating19 { get; set; }

    [JsonProperty("20")]
    public string Rating20 { get; set; }
}

public class PosterImage
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
    public PosterImageMeta Meta { get; set; }
}

public class PosterImageMeta
{
    [JsonProperty("dimensions")]
    public Dimensions Dimensions { get; set; }
}

public class Dimensions
{
    [JsonProperty("tiny")]
    public ImageSize Tiny { get; set; }

    [JsonProperty("large")]
    public ImageSize Large { get; set; }

    [JsonProperty("small")]
    public ImageSize Small { get; set; }

    [JsonProperty("medium")]
    public ImageSize Medium { get; set; }
}

public class ImageSize
{
    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }
}
