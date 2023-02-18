using Bogus;
using Miotto.GitHubTopsters.Domain.Dtos;

namespace Miotto.GitHubTopsters.Domain.Tests.Fakers
{
    public class GithubRepoLanguageFaker
    {
        public static GithubRepoLanguageResponse ResponseFaker()
        {
            var fk = new Faker();
            return new GithubRepoLanguageResponse()
            {
                Language = fk.Random.Word(),
                Repositories = new List<GithubRepoDto>
                {
                    GithubRepoDtoFaker.Dto()
                }
            };
        }
    }
}
