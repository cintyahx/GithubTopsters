namespace Miotto.GitHubTopsters.Gateway
{
    public static class GithubSettingsConstants
    {
        public const string BaseUrl = "https://api.github.com";
        public const string SearchQuery = "search/repositories?type=Repositories&per_page={0}&sort=stars&order=desc&q=+language:{1}";
    }
}
