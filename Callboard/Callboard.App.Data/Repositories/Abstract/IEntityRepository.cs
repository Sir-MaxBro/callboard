using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface IEntityRepository<T>
    {
        IReadOnlyCollection<T> Items { get; }
    }
}
