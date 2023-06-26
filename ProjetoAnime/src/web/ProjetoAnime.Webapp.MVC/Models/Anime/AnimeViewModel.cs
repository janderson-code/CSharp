namespace ProjetoAnime.Webapp.MVC.Models.Anime;

public class AnimeKitsuViewModel
{
    public List<AnimeDataViewModel> Data { get; set; }

}

public class AnimeDataViewModel
{
    public AnimeAttributes Attributes { get; set; }
}

public class AnimeAttributes
{
    [DisplayName("Nome")] public string Slug { get; set; }
    [DisplayName("Sinopse")] public string Synopsis { get; set; }
    public AnimeTitles Titles { get; set; }
    [DisplayName("Titulo Original")] public string CanonicalTitle { get; set; }
    public List<string> AbbreviatedTitles { get; set; }
    [DisplayName("Data de Inicio")] public string StartDate { get; set; }
    [DisplayName("Data de fim")] public string EndDate { get; set; }
    [DisplayName("Tipo")] public string Subtype { get; set; }
    [DisplayName("Status")] public string Status { get; set; }
    public ImageData PosterImage { get; set; }
    public ImageData CoverImage { get; set; }
    [DisplayName("Quantidade Episódios")] public int? EpisodeCount { get; set; }
    [DisplayName("Tamanho dos Episódios")] public int? EpisodeLength { get; set; }
    [DisplayName("Link do Youtube")] public string YoutubeVideoId { get; set; }
    [DisplayName("Tipo da Mídia")] public string ShowType { get; set; }
}

public class AnimeTitles
{
    [DisplayName("Título em Inglês")] public string English { get; set; }
    [DisplayName("Título em Romaji")] public string EnglishJapanese { get; set; }
    [DisplayName("Título em Japonês")] public string Japanese { get; set; }
}

public class ImageData
{
    public string Tiny { get; set; }
    public string Large { get; set; }
    public string Small { get; set; }
    public string Medium { get; set; }
    public string Original { get; set; }
}
