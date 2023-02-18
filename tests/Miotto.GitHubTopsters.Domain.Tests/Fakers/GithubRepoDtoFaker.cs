using Bogus;
using Miotto.GitHubTopsters.Domain.Dtos;

namespace Miotto.GitHubTopsters.Domain.Tests.Fakers
{
    public static class GithubRepoDtoFaker
    {
        public static GithubRepoDto Dto()
        {
            return new Faker<GithubRepoDto>()
                .Rules((fk, o) =>
                    new GithubRepoDto
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
                        Owner = new GithubRepoOwnerDto()
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
