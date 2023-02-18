using Microsoft.EntityFrameworkCore;
using Miotto.GitHubTopsters.Domain.Entities;
using Miotto.GitHubTopsters.Domain.Interfaces;

namespace Miotto.GitHubTopsters.Infra.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IEntity, new()
{
    private static readonly IEnumerable<EntityState> EntityMaintainedStatus = new[] { EntityState.Modified, EntityState.Added, EntityState.Deleted };

    private readonly GithubTopstersContext _githubTopstersContext;
    protected DbSet<TEntity> Set { get; private set; }

    protected RepositoryBase(GithubTopstersContext githubTopstersContext)
    {
        _githubTopstersContext = githubTopstersContext;
        Set = githubTopstersContext.Set<TEntity>();
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await Set.AddRangeAsync(entities);
        await _githubTopstersContext.SaveChangesAsync();
    }
}
