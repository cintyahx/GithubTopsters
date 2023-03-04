namespace Miotto.GitHubTopsters.Util
{
    public static class GithubSettingsConstants
    {
        public const string BaseUrl = "https://api.github.com";
        public const string SearchQuery = "search/repositories?type=Repositories&per_page={0}&sort=stars&order=desc&q=+language:{1}";
        public const int QuantityDefault = 3;
        public static readonly List<string> LanguagesDefault = new List<string>()
        {
            "C#",
            "Vue",
            "TypeScript",
            "JavaScript",
            "Python"
        };
    }
}
