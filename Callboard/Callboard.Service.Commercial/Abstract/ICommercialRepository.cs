using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.Service.Commercial
{
    [ServiceContract]
    public interface ICommercialRepository
    {
        [OperationContract]
        Commercial[] GetCommercials();
    }
}
