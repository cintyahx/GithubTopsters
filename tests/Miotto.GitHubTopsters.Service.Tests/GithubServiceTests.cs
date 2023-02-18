using AutoMapper;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Miotto.GitHubTopsters.Domain.Dtos;
using Miotto.GitHubTopsters.Domain.Entities;
using Miotto.GitHubTopsters.Domain.Interfaces;
using Miotto.GitHubTopsters.Domain.Tests.Fakers;
using Miotto.GitHubTopsters.Gateway;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace Miotto.GitHubTopsters.Service.Tests
{
    public class GithubServiceTests
    {
        private readonly GithubService _githubService;

        private readonly Mock<IValidator<SearchGithubDto>> _validator;

        private readonly Mock<IGithubGateway> _githubGateway;
        private readonly Mock<IGithubRepoRepository> _githubRepoRepository;
        private readonly Mock<IMapper> _mapper;

        public GithubServiceTests()
        {
            _validator = new Mock<IValidator<SearchGithubDto>>();
            _githubGateway = new Mock<IGithubGateway>();
            _githubRepoRepository = new Mock<IGithubRepoRepository>();
            _mapper = new Mock<IMapper>();

            _githubService = new GithubService(_validator.Object, _githubGateway.Object, _githubRepoRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task ShouldReturnErrorsWhenDtoIsInvalid()
        {
            _validator.Setup(x => x.ValidateAsync(It.IsAny<SearchGithubDto>(), CancellationToken.None))
                .ReturnsAsync(new ValidationResult() { Errors = new List<ValidationFailure> { new ValidationFailure("aaa", "aaa") } });

            var result = await _githubService.ListReposByLanguageAsync(new SearchGithubDto());

            result.Error.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldReturnDataFromBdWhenStatusCodeNotOk()
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound
            };

            var reposDb = new List<GithubRepo>
            {
                GithubRepoFaker.Repo()
            };

            _validator.Setup(x => x.ValidateAsync(It.IsAny<SearchGithubDto>(), CancellationToken.None))
                .ReturnsAsync(new ValidationResult());

            _githubGateway.Setup(x => x.GetGithubRepos(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(Task.FromResult(response));

            _githubRepoRepository.Setup(x => x.GetByLanguageAsync(It.IsAny<string>()))
                .ReturnsAsync(reposDb);

            var dto = SearchGithubDtoFaker.DtoFaker(2, 3);

            var result = await _githubService.ListReposByLanguageAsync(dto);

            result.Error.Should().BeFalse();
            result.Errors.Should().BeEmpty();
            result.Data.Should().NotBeEmpty();

            _githubRepoRepository.Verify(x => x.GetByLanguageAsync(It.IsAny<string>()), Times.Exactly(dto.Languages.Count));
            _githubRepoRepository.Verify(x => x.DeleteByLanguageAsync(It.IsAny<string>()), Times.Never);
            _githubRepoRepository.Verify(x => x.CreateRangeAsync(It.IsAny<IEnumerable<GithubRepo>>()), Times.Never);
        }

        [Fact]
        public async Task ShouldReturnDataWhenStatusCodeOk()
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(GithubRepoLanguageFaker.ResponseFaker()))
            };

            _validator.Setup(x => x.ValidateAsync(It.IsAny<SearchGithubDto>(), CancellationToken.None))
                .ReturnsAsync(new ValidationResult());

            _githubGateway.Setup(x => x.GetGithubRepos(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(Task.FromResult(response));

            var dto = SearchGithubDtoFaker.DtoFaker(2, 3);

            var result = await _githubService.ListReposByLanguageAsync(dto);

            result.Error.Should().BeFalse();
            result.Errors.Should().BeEmpty();
            result.Data.Should().NotBeEmpty();

            _githubRepoRepository.Verify(x => x.GetByLanguageAsync(It.IsAny<string>()), Times.Never);
            _githubRepoRepository.Verify(x => x.DeleteByLanguageAsync(It.IsAny<string>()), Times.Exactly(dto.Languages.Count));
            _githubRepoRepository.Verify(x => x.CreateRangeAsync(It.IsAny<IEnumerable<GithubRepo>>()), Times.Exactly(dto.Languages.Count));
        }
    }
}