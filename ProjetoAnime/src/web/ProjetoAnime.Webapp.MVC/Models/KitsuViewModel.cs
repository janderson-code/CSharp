using ProjetoAnime.Webapp.MVC.Models.Anime;
using ProjetoManga.Webapp.MVC.Models.Manga;

namespace ProjetoAnime.Webapp.MVC.Models
{
    public class KitsuViewModel
    {
        public AnimeKitsuViewModel Anime { get; set; }

        public MangaKitsuViewModel Manga { get; set; }
    }
}
