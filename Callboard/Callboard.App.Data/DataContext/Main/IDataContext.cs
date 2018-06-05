using System.Collections.Generic;

namespace Callboard.App.Data.DataContext.Main
{
    public interface IDataContext<T>
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(int id);

        void Save(T obj);

        void Delete(int id);
    }
}