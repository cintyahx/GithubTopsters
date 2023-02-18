using Miotto.GitHubTopsters.Domain.Dtos;
using Miotto.GitHubTopsters.Util;

namespace Miotto.GitHubTopsters.Service
{
    public interface IGithubService
    {
        Task<Result<List<GithubRepoLanguageResponse>>> ListReposByLanguageAsync(SearchGithubDto searchParams);
    }
}
