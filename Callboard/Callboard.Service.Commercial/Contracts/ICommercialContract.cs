using System.ServiceModel;

namespace Callboard.Service.Commercial
{
    [ServiceContract]
    public interface ICommercialContract
    {
        [OperationContract]
        Commercial[] GetCommercials();
    }
}
