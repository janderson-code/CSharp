using Newtonsoft.Json;

namespace ProjetoAnime.KitsuGateway.API.Models;

public class IncludedAttributes
{
    [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

    [JsonProperty("slug")] public string Slug { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("canonicalTitle")] public string CanonicalTitle { get; set; }

    [JsonProperty("abbreviatedTitles")] public List<string> AbbreviatedTitles { get; set; }

    [JsonProperty("averageRating")] public string AverageRating { get; set; }

    [JsonProperty("ratingFrequencies")] public RatingFrequencies RatingFrequencies { get; set; }

    [JsonProperty("userCount")] public int UserCount { get; set; }

    [JsonProperty("favoritesCount")] public int FavoritesCount { get; set; }

    [JsonProperty("startDate")] public DateTime StartDate { get; set; }

    [JsonProperty("endDate")] public DateTime? EndDate { get; set; }

    [JsonProperty("popularityRank")] public int PopularityRank { get; set; }

    [JsonProperty("ratingRank")] public int RatingRank { get; set; }

    [JsonProperty("ageRating")] public string AgeRating { get; set; }

    [JsonProperty("ageRatingGuide")] public string AgeRatingGuide { get; set; }

    [JsonProperty("subtype")] public string Subtype { get; set; }

    [JsonProperty("status")] public string Status { get; set; }

    [JsonProperty("tba")] public string Tba { get; set; }

    [JsonProperty("posterImage")] public PosterImage PosterImage { get; set; }

    [JsonProperty("coverImage")] public CoverImage CoverImage { get; set; }

    [JsonProperty("episodeCount")] public int EpisodeCount { get; set; }

    [JsonProperty("episodeLength")] public int EpisodeLength { get; set; }

    [JsonProperty("totalLength")] public int TotalLength { get; set; }

    [JsonProperty("youtubeVideoId")] public string YoutubeVideoId { get; set; }

    [JsonProperty("showType")] public string ShowType { get; set; }

    [JsonProperty("nsfw")] public bool Nsfw { get; set; }
}