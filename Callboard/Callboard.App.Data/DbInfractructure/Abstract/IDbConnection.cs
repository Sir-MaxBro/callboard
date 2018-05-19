using System;

namespace Callboard.App.Data.DbInfractructure
{
    internal interface IDbConnection : IDisposable
    {
        void Open();

        void Close();
    }
}
