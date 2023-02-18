namespace Miotto.GitHubTopsters.Gateway
{
    public interface IGithubGateway
    {
        Task<HttpResponseMessage> GetGithubRepos(string language, int quantity);
    }
}
