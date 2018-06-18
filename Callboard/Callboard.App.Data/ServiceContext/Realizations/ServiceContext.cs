using Callboard.App.General.Loggers.Main;
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Service = Callboard.App.Data.CommercialService;

namespace Callboard.App.Data.ServiceContext.Realizations
{
    internal class ServiceContext<T> : IServiceContext<T>
    {
        private ILoggerWrapper _logger;

        public ServiceContext(ILoggerWrapper logger)
        {
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }

        public TOut GetData<TOut>(string endpointConfigurationName, Configuration configuration, EndpointAddress remoteAddress, Func<T, TOut> getData)
        {
            TOut data = default(TOut);

            using (var channelFactory = new ConfigurationChannelFactory<T>(endpointConfigurationName, configuration, remoteAddress))
            {
                try
                {
                    var channel = channelFactory.CreateChannel();
                    data = getData(channel);
                    channelFactory.Close();
                }
                catch (ConfigurationErrorsException ex)
                {
                    _logger.WarnFormat($"{ ex.Message }");
                }
                catch (TimeoutException ex)
                {
                    _logger.WarnFormat($"Cannot connect to { nameof(T) }.\n { ex.Message }");
                }
                catch (FaultException<Service::CommercialNotFound> ex)
                {
                    _logger.WarnFormat($"{ ex.Message }");
                }
                catch (FaultException ex)
                {
                    _logger.WarnFormat($"Cannot connect to { nameof(T) }.\n { ex.Message }");
                }
                catch (CommunicationException ex)
                {
                    _logger.WarnFormat($"Cannot connect to { nameof(T) }.\n { ex.Message }");
                }
                catch (Exception ex)
                {
                    _logger.WarnFormat($"Cannot connect to { nameof(T) }.\n { ex.Message }");
                }
            }

            return data;
        }
    }
}