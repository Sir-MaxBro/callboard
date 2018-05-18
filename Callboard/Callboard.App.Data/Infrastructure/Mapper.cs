using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Infrastructure
{
    internal class Mapper
    {
        public static IReadOnlyCollection<T> MapCollection<T>(DbDataReader reader)
            where T : new()
        {
            throw new NotImplementedException();
        }

        public static T MapElement<T>(DbDataReader reader)
            where T : new()
        {
            throw new NotImplementedException();
        }

        private static T Map<T>(DbDataReader reader)
            where T : new()
        {
            throw new NotImplementedException();
        }
    }
}
