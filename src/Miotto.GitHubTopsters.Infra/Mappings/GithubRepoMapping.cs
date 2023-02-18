using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miotto.GitHubTopsters.Domain.Entities;

namespace Miotto.GitHubTopsters.Infra.Mappings
{
    public class GithubRepoMapping : IEntityTypeConfiguration<GithubRepo>
    {
        public void Configure(EntityTypeBuilder<GithubRepo> builder)
        {
            builder.Property(x => x.RepoId).IsRequired();
            builder.Property(x => x.FullName);
            builder.Property(x => x.Url);
            builder.Property(x => x.Description);
            builder.Property(x => x.PushedAt);
            builder.Property(x => x.Size);
            builder.Property(x => x.Stars);
            builder.Property(x => x.Language);
            builder.Property(x => x.Forks);
            builder.Property(x => x.OpenIssues);
            builder.Property(x => x.Watchers);
            builder.Property(x => x.DefaultBranch);

            builder.HasOne(x => x.Owner)
                   .WithMany(x => x.Repositories)
                   .HasForeignKey(x => x.OwnerId);
        }
    }
}
