using Bogus;
using Miotto.GitHubTopsters.Domain.Dtos;

namespace Miotto.GitHubTopsters.Domain.Tests.Fakers
{
    public static class SearchGithubDtoFaker
    {
        public static SearchGithubDto DtoFaker(int quantity, int languagesListLength)
        {
            var fk = new Faker();
            return new SearchGithubDto()
            {
                Quantity = quantity,
                Languages = fk.Random.WordsArray(languagesListLength).ToList()
            };
        }
    }
}
