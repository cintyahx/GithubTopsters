using Miotto.GitHubTopsters.Domain.Interfaces;
using Newtonsoft.Json;

namespace Miotto.GitHubTopsters.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; protected set; }
    }
}
