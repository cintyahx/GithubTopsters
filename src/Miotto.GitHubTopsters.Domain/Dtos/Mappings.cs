using AutoMapper;
using Miotto.GitHubTopsters.Domain.Entities;

namespace Miotto.GitHubTopsters.Domain.Dtos
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<GithubRepoOwnerDto, GithubRepoOwner>();
            CreateMap<GithubRepoDto, GithubRepo>();

            CreateMap<GithubRepoOwner, GithubRepoOwnerDto>();
            CreateMap<GithubRepo, GithubRepoDto>();
        }
    }
}
