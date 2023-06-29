using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAnime.Anime.API.Models;

public class AnimeViewModel
{
    [DisplayName("Nome Completo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }

    [DisplayName("Nome Completo")]
    public string Sinopse { get; set; }

    [DisplayName("Data de Lançamento")]
    [DataType(DataType.DateTime)]
    public DateTime DataInicio { get; set; }

    [DisplayName("Data de Conclusão")]
    [DataType(DataType.DateTime)]
    public DateTime DataFim { get; set; }

    [DisplayName("Nome em Japonês")]
    public string NomeOriginal { get; set; }

    public string Imagem { get; set; }
}