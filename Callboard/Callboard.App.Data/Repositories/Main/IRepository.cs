using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Main
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(int id);

        void Save(T obj);

        void Delete(int id);
    }
}