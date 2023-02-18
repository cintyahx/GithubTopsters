namespace Miotto.GitHubTopsters.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
    }
}
