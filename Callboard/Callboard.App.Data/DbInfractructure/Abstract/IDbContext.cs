using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.DbInfractructure
{
    internal interface IDbContext : IDbConnection
    {
        DbDataReader ExecuteProcedure(string procedureName, IDictionary<string, object> values);
    }
}
