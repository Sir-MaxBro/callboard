using System.Collections.Generic;
using System.Data;

namespace Callboard.App.Data.Context.Main
{
    public interface ISqlDbContext
    {
        string ConnectionString { get; set; }

        DataSet ExecuteProcedure(string procedureName, IDictionary<string, object> values = null);

        void ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null);
    }
}