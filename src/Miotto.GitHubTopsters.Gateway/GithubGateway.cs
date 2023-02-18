using System.Web;

namespace Miotto.GitHubTopsters.Gateway
{
    public class GithubGateway : IGithubGateway
    {
        private readonly HttpClient _httpClient;

        public GithubGateway()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetGithubRepos(string language, int quantity)
        {
            var languageFormated = HttpUtility.UrlEncode(language);
            var baseUrl = new Uri(GithubSettingsConstants.BaseUrl);
            _httpClient.BaseAddress = baseUrl;

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHubTopsters");

            var url = baseUrl +
                string.Format(GithubSettingsConstants.SearchQuery,
                quantity,
            languageFormated);

            var httpResponse = await _httpClient.GetAsync(url);

            return httpResponse;
        }
    }
}
