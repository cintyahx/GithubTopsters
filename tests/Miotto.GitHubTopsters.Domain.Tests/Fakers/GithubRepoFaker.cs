using Bogus;
using Miotto.GitHubTopsters.Domain.Entities;

namespace Miotto.GitHubTopsters.Domain.Tests.Fakers
{
    public static class GithubRepoFaker
    {
        public static GithubRepo Repo()
        {
            return new Faker<GithubRepo>()
                .Rules((fk, o) =>
                    new GithubRepo
                    {
                        Name = fk.Random.Word(),
                        FullName = fk.Random.Word(),
                        Url = fk.Random.Word(),
                        Description = fk.Random.Word(),
                        PushedAt = fk.Date.Past(),
                        Size = fk.Random.Long(),
                        Stars = fk.Random.Long(),
                        Language = fk.Random.Word(),
                        Forks = fk.Random.Long(),
                        OpenIssues = fk.Random.Long(),
                        Watchers = fk.Random.Long(),
                        DefaultBranch = fk.Random.Word(),
                        Owner = new GithubRepoOwner()
                        {
                            Login = fk.Random.Word(),
                            AvatarUrl = fk.Random.Word(),
                            Url = fk.Random.Word()
                        }
                    }
                );
        }
    }
}
