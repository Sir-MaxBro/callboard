using System.Collections.Generic;

namespace Callboard.App.Business.Services
{
    public interface IEntityService<T>
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(int id);

        void Save(T obj);

        void Delete(int id);
    }
}