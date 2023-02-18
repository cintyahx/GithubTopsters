namespace Miotto.GitHubTopsters.Domain.Entities
{
    public class GithubRepo : BaseEntity
    {
        public long RepoId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTimeOffset PushedAt { get; set; }
        public long Size { get; set; }
        public long Stars { get; set; }
        public string Language { get; set; }
        public long Forks { get; set; }
        public long OpenIssues { get; set; }
        public long Watchers { get; set; }
        public string DefaultBranch { get; set; }

        public virtual Guid OwnerId { get; set; }
        public virtual GithubRepoOwner Owner { get; set; }
    }
}
