using Miotto.GitHubTopsters.Domain.Entities;

namespace Miotto.GitHubTopsters.Domain.Interfaces
{
    public interface IGithubRepoRepository : IRepository<GithubRepo>
    {
        Task<IEnumerable<GithubRepo>> GetByLanguageAsync(string language);
        Task DeleteByLanguageAsync(string language);
    }
}
