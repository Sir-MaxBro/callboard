using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Data.Infrastructure
{
    internal class Mapper
    {
        public static T Map<T>()
            where T : new()
        {
            return new T();
        }
    }
}
