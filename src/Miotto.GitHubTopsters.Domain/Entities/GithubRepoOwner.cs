using Newtonsoft.Json;

namespace Miotto.GitHubTopsters.Domain.Entities
{
    public class GithubRepoOwner : BaseEntity
    {
        public virtual IList<GithubRepo> Repositories { get; set; }

        public long OwnerId { get; set; }
        public string Login { get; set; }
        public string AvatarUrl { get; set; }
        public string Url { get; set; }
    }
}
