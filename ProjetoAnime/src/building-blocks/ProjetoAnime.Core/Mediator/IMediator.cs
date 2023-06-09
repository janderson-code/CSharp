using FluentValidation.Results;
using ProjetoAnime.Core.Messages;

namespace ProjetoAnime.Core.Mediator
{
    public interface IMediator
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}