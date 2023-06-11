namespace ProjetoAnime.Core.Communication;

public class ResponseErrorMessages
{        public ResponseErrorMessages()
    {
        Mensagens = new List<string>();
    }
    public IList<string> Mensagens { get; set; }
}