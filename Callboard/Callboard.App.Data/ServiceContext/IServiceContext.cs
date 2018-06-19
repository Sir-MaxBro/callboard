using System;
using System.Configuration;
using System.ServiceModel;

namespace Callboard.App.Data.ServiceContext
{
    public interface IServiceContext<T>
    {
        TOut GetData<TOut>(string endpointConfigurationName, Configuration configuration, EndpointAddress remoteAddress, Func<T, TOut> getData);
    }
}