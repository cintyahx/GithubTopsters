using Microsoft.EntityFrameworkCore;
using Miotto.GitHubTopsters.Domain.Entities;
using Miotto.GitHubTopsters.Domain.Interfaces;

namespace Miotto.GitHubTopsters.Infra.Repositories
{
    public class GithubRepoRepository : RepositoryBase<GithubRepo>, IGithubRepoRepository
    {
        private readonly GithubTopstersContext _githubTopstersContext;
        public GithubRepoRepository(GithubTopstersContext githubTopstersContext) : base(githubTopstersContext)
        {
            _githubTopstersContext = githubTopstersContext;
        }

        public async Task DeleteByLanguageAsync(string language)
        {
            var repos = await GetByLanguageAsync(language);
            Set.RemoveRange(repos);
            await _githubTopstersContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GithubRepo>> GetByLanguageAsync(string language)
        {
            return await Set.Where(x => x.Language == language)
                .Include(x => x.Owner)
                .ToListAsync();
        }
    }
}
