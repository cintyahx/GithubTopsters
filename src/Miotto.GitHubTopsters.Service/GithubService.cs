using AutoMapper;
using FluentValidation;
using Miotto.GitHubTopsters.Domain.Dtos;
using Miotto.GitHubTopsters.Domain.Entities;
using Miotto.GitHubTopsters.Domain.Interfaces;
using Miotto.GitHubTopsters.Gateway;
using Miotto.GitHubTopsters.Util;
using Newtonsoft.Json;

namespace Miotto.GitHubTopsters.Service
{
    public class GithubService : IGithubService
    {
        private readonly IValidator<SearchGithubDto> _validator;
        private readonly IGithubGateway _githubGateway;
        private readonly IGithubRepoRepository _githubRepoRepository;
        private readonly IMapper _mapper;

        public GithubService(IValidator<SearchGithubDto> validator, IGithubGateway githubGateway, IGithubRepoRepository githubRepoRepository, IMapper mapper)
        {
            _validator = validator;
            _githubGateway = githubGateway;
            _githubRepoRepository = githubRepoRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GithubRepoLanguageResponse>>> ListReposByLanguageAsync(SearchGithubDto searchGithubDto)
        {
            var result = new Result<List<GithubRepoLanguageResponse>>(new List<GithubRepoLanguageResponse>());

            var validationResult = await _validator.ValidateAsync(searchGithubDto);
            if (!validationResult.IsValid)
            {
                result.Errors = validationResult.Errors;
                return result;
            }

            foreach (string language in searchGithubDto.Languages)
            {
                GithubRepoLanguageResponse response;

                var httpResponse = await _githubGateway.GetGithubRepos(language, searchGithubDto.Quantity);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var resultRequest = await httpResponse.Content.ReadAsStringAsync();

                    response = JsonConvert.DeserializeObject<GithubRepoLanguageResponse>(resultRequest)!;
                    response.Language = language;

                    var repos = _mapper.Map<List<GithubRepo>>(response.Repositories);

                    await UpdateGithubRepos(language, repos);
                }
                else
                {
                    var reposDb = await _githubRepoRepository.GetByLanguageAsync(language);

                    response = new GithubRepoLanguageResponse
                    {
                        Language = language,
                        Repositories = _mapper.Map<List<GithubRepoDto>>(reposDb.Take(searchGithubDto.Quantity).ToList())
                    };
                }

                result.Data.Add(response);
            }
            return result;
        }

        private async Task UpdateGithubRepos(string language, IList<GithubRepo> repositories)
        {
            if (repositories.Any())
            {
                await _githubRepoRepository.DeleteByLanguageAsync(language);

                await _githubRepoRepository.CreateRangeAsync(repositories);
            }
        }
    }
}
