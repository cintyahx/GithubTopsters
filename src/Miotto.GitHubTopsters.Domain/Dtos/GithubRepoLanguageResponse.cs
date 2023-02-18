using Miotto.GitHubTopsters.Domain.Entities;
using Newtonsoft.Json;

namespace Miotto.GitHubTopsters.Domain.Dtos
{
    public class GithubRepoLanguageResponse
    {
        public string Language { get; set; }

        [JsonProperty("items")]
        public IList<GithubRepoDto> Repositories { get; set; }
    }

    public partial class GithubRepoDto
    {
        [JsonProperty("id")]
        public long RepoId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("html_url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pushed_at")]
        public DateTimeOffset PushedAt { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("stargazers_count")]
        public long Stars { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("forks")]
        public long Forks { get; set; }

        [JsonProperty("open_issues")]
        public long OpenIssues { get; set; }

        [JsonProperty("watchers")]
        public long Watchers { get; set; }

        [JsonProperty("default_branch")]
        public string DefaultBranch { get; set; }

        [JsonProperty("owner")]
        public virtual GithubRepoOwnerDto Owner { get; set; }
    }

    public partial class GithubRepoOwnerDto
    {
        [JsonProperty("id")]
        public long OwnerId { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("html_url")]
        public string Url { get; set; }
    }
}
