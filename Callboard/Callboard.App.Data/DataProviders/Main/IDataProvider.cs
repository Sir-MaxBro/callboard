using System.Collections.Generic;

namespace Callboard.App.Data.DataProviders.Main
{
    public interface IDataProvider<T>
    {
        IReadOnlyCollection<T> GetAll();

        T Get();

        void Save(T obj);

        void Delete();
    }
}