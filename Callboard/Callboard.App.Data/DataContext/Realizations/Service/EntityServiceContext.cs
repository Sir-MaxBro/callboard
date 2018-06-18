using Callboard.App.Data.ServiceContext;
using Callboard.App.General.Helpers;
using System;
using System.ServiceModel;

namespace Callboard.App.Data.DataContext.Realizations.Service
{
    internal class EntityServiceContext<T>
    {
        private IServiceContext<T> _context;
        public EntityServiceContext(IServiceContext<T> context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public TOut GetData<TOut>(string endpointConfigurationName, EndpointAddress remoteAddress, Func<T, TOut> getData)
        {
            var configuration = ConfigurationHelper.GetExecutingAssemblyConfig(this);
            var commercials = _context.GetData(endpointConfigurationName, configuration, remoteAddress, getData);
            return commercials;
        }
    }
}