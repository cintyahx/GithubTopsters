using FluentAssertions;
using Miotto.GitHubTopsters.Domain.Tests.Fakers;
using Miotto.GitHubTopsters.Domain.Validators;

namespace Miotto.GitHubTopsters.Domain.Tests
{
    public class SearchGithubValidatorTests
    {
        private readonly SearchGithubValidator _searchGithubValidator;

        public SearchGithubValidatorTests()
        {
            _searchGithubValidator = new SearchGithubValidator();
        }

        [Theory]
        [InlineData(0, 4, false)]
        [InlineData(-1, 0, false)]
        [InlineData(3, 3, true)]
        public void SearchGithubDtoShouldValidateCorrectly(int quantity, int languagesListLength, bool success)
        {
            var searchGithubDto = SearchGithubDtoFaker.DtoFaker(quantity, languagesListLength);

            var resultValidation = _searchGithubValidator.Validate(searchGithubDto);

            resultValidation.Should().NotBeNull();
            resultValidation.IsValid.Should().Be(success);
            resultValidation.Errors.Any().Should().Be(!success);
        }
    }
}
