using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface IEntityProvider<T>
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(int id);

        void Save(T obj);

        void Delete(int id);
    }
}