using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface IEntityRepository<T>
    {
        IReadOnlyCollection<T> Items { get; }
    }
}