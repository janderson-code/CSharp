namespace ProjetoManga.Webapp.MVC.Models.Manga
{
    public class MangaKitsuViewModel
    {
        public List<MangaDataViewModel> Data { get; set; }
    }

    public class MangaDataViewModel
    {
        public MangaAttributes Attributes { get; set; }
    }

    public class MangaAttributes
    {
        [DisplayName("Nome")] public string Slug { get; set; }
        [DisplayName("Sinopse")] public string Synopsis { get; set; }
        public MangaTitles Titles { get; set; }
        [DisplayName("Titulo Original")] public string CanonicalTitle { get; set; }
        public List<string> AbbreviatedTitles { get; set; }
        [DisplayName("Data de Inicio")] public string StartDate { get; set; }
        [DisplayName("Data de fim")] public string EndDate { get; set; }
        [DisplayName("Tipo")] public string Subtype { get; set; }
        [DisplayName("Status")] public string Status { get; set; }
        public ImageData PosterImage { get; set; }
        public ImageData CoverImage { get; set; }
        [DisplayName("Quantidade Capítulos")] public int? ChapterCount { get; set; }
        [DisplayName("Volumes")] public int? VolumeCount { get; set; }
        [DisplayName("Revista")] public string Serialization { get; set; }
        [DisplayName("Tipo da Mídia")] public string MangaType { get; set; }
    }

    public class MangaTitles
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
}