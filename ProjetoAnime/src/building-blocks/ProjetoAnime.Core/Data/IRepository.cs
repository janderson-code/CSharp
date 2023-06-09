using ProjetoAnime.Core.DomainObjects;

namespace ProjetoAnime.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}