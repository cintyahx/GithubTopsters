using Microsoft.EntityFrameworkCore;
using Miotto.GitHubTopsters.Infra.Mappings;

namespace Miotto.GitHubTopsters.Infra
{
    public class GithubTopstersContext : DbContext
    {
        protected GithubTopstersContext() { }

        public GithubTopstersContext(DbContextOptions<GithubTopstersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GithubRepoOwnerMapping());
            modelBuilder.ApplyConfiguration(new GithubRepoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
