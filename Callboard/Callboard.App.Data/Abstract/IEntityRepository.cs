using System.Collections.Generic;

namespace Callboard.App.Data.Abstract
{
    public interface IEntityRepository<T>
    {
        IReadOnlyCollection<T> Items { get; }
    }
}
