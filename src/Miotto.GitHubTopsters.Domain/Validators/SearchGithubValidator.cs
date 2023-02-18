using FluentValidation;
using Miotto.GitHubTopsters.Domain.Dtos;
using Miotto.GitHubTopsters.Domain.Resources;

namespace Miotto.GitHubTopsters.Domain.Validators
{
    public class SearchGithubValidator : AbstractValidator<SearchGithubDto>
    {
        public SearchGithubValidator()
        {
            ValidateQuantity();
            ValidateLanguageList();
        }

        private void ValidateQuantity()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage(string.Format(ValidationResource.LessThanZero, FieldResource.ResultQuantity));
        }
        private void ValidateLanguageList()
        {
            RuleFor(x => x.Languages)
                .NotEmpty().WithMessage(string.Format(ValidationResource.EmptyList, 1, FieldResource.Language));
        }
    }
}
