using Callboard.App.Data.Mappers;
using System.Collections.Generic;
using System.Data;

namespace Callboard.App.Data.DataProviders.Main
{
    public interface ISqlDataProvider<T> : IDataProvider<T>
    {
        string ProcedureName { get; set; }

        IDictionary<string, object> Values { get; set; }

        Mapper<DataSet, T> Mapper { get; set; }

        string ConnectionString { get; set; }

        void ClearValues();
    }
}