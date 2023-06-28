namespace ProjetoAnime.KitsuGateway.API.Models.Manga;
public class MangaKitsuResponse
{
    [JsonProperty("data")]
    public List<MangaData> Data { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }
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
    public Relationships Relationships { get; set; }
}

public class Links
{
    [JsonProperty("self")]
    public string Self { get; set; }

    [JsonProperty("related")]
    public string Related { get; set; }
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
    public Titles Titles { get; set; }

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
    public PosterImage PosterImage { get; set; }

    [JsonProperty("coverImage")]
    public CoverImage CoverImage { get; set; }

    [JsonProperty("chapterCount")]
    public int? ChapterCount { get; set; }

    [JsonProperty("volumeCount")]
    public int? VolumeCount { get; set; }

    [JsonProperty("serialization")]
    public string Serialization { get; set; }

    [JsonProperty("mangaType")]
    public string MangaType { get; set; }
}

public class Titles
{
    [JsonProperty("en")]
    public string En { get; set; }

    [JsonProperty("en_jp")]
    public string EnJp { get; set; }

    [JsonProperty("ja_jp")]
    public string JaJp { get; set; }
}

public class PosterImage
{
    [JsonProperty("original")]
    public string Original { get; set; }

    [JsonProperty("tiny")]
    public string Tiny { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }

    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }
}

public class CoverImage
{
    [JsonProperty("tiny")]
    public string Tiny { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }

    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("original")]
    public string Original { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }
}

public class Meta
{
    [JsonProperty("dimensions")]
    public Dimensions Dimensions { get; set; }
}

public class Dimensions
{
    [JsonProperty("tiny")]
    public Dimension Tiny { get; set; }

    [JsonProperty("large")]
    public Dimension Large { get; set; }

    [JsonProperty("small")]
    public Dimension Small { get; set; }
}

public class Dimension
{
    [JsonProperty("width")]
    public int? Width { get; set; }

    [JsonProperty("height")]
    public int? Height { get; set; }
}

public class Relationships
{
    [JsonProperty("genres")]
    public RelationshipItem Genres { get; set; }

    [JsonProperty("categories")]
    public RelationshipItem Categories { get; set; }

    [JsonProperty("castings")]
    public RelationshipItem Castings { get; set; }

    [JsonProperty("installments")]
    public RelationshipItem Installments { get; set; }

    [JsonProperty("mappings")]
    public RelationshipItem Mappings { get; set; }

    [JsonProperty("reviews")]
    public RelationshipItem Reviews { get; set; }

    [JsonProperty("mediaRelationships")]
    public RelationshipItem MediaRelationships { get; set; }

    [JsonProperty("characters")]
    public RelationshipItem Characters { get; set; }

    [JsonProperty("staff")]
    public RelationshipItem Staff { get; set; }

    [JsonProperty("productions")]
    public RelationshipItem Productions { get; set; }

    [JsonProperty("quotes")]
    public RelationshipItem Quotes { get; set; }

    [JsonProperty("chapters")]
    public RelationshipItem Chapters { get; set; }

    [JsonProperty("mangaCharacters")]
    public RelationshipItem MangaCharacters { get; set; }

    [JsonProperty("mangaStaff")]
    public RelationshipItem MangaStaff { get; set; }
}

public class RelationshipItem
{
    [JsonProperty("links")]
    public Links Links { get; set; }
}
