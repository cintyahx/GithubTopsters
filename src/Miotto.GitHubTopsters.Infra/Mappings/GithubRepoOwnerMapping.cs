using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miotto.GitHubTopsters.Domain.Entities;

namespace Miotto.GitHubTopsters.Infra.Mappings
{
    public class GithubRepoOwnerMapping : IEntityTypeConfiguration<GithubRepoOwner>
    {
        public void Configure(EntityTypeBuilder<GithubRepoOwner> builder)
        {
            builder.Property(x => x.OwnerId).IsRequired();
            builder.Property(x => x.Login);
            builder.Property(x => x.AvatarUrl);
            builder.Property(x => x.Url);
        }
    }
}
