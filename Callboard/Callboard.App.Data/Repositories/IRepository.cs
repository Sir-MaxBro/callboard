using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface IRepository<T>
    {
        IResult<IReadOnlyCollection<T>> GetAll();

        IResult<T> GetById(int id);

        IResult<T> Save(T obj);

        IResult<T> Delete(int id);
    }
}