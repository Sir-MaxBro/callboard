using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Business.Abstract
{
    public interface IEntityRepository<T>
    {
        IReadOnlyCollection<T> Items { get; set; }    
    }
}
