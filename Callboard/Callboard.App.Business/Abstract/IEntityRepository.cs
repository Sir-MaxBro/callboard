using System.Collections.Generic;

namespace Callboard.App.Business.Abstract
{
    public interface IEntityRepository<T>
    {
        IReadOnlyCollection<T> Items { get; }
    }
}