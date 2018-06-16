using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Helpers;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Service = Callboard.App.Data.CommercialService;

namespace Callboard.App.Data.DataContext.Realizations.Service
{
    internal class CommercialServiceContext : ICommercialContext
    {
        private ILoggerWrapper _logger;
        public CommercialServiceContext(ILoggerWrapper logger)
        {
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }

        public IReadOnlyCollection<Commercial> GetCommercials()
        {
            IReadOnlyCollection<Commercial> commercials = null;
            try
            {
                Service::ICommercialContract commercialContract = this.GetCommercialContract();
                commercials = commercialContract.GetCommercials().Select(MapCommercial).ToList();
            }
            catch (ConfigurationErrorsException ex)
            {
                _logger.WarnFormat($"{ ex.Message }");
            }
            catch (TimeoutException ex)
            {
                _logger.WarnFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
            }
            catch (FaultException<Service::CommercialNotFound> ex)
            {
                _logger.WarnFormat($"{ ex.Message }");
            }
            catch (FaultException ex)
            {
                _logger.WarnFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
            }
            catch (CommunicationException ex)
            {
                _logger.WarnFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
            }
            catch (Exception ex)
            {
                _logger.WarnFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
            }
            return commercials;
        }

        private Commercial MapCommercial(Service::Commercial commercial)
        {
            return new Commercial
            {
                Id = commercial.Id,
                Image = this.MapImage(commercial.Image)
            };
        }

        private Image MapImage(Service::Image image)
        {
            return new Image
            {
                Data = image.Data,
                Extension = image.Extension
            };
        }

        private Service::ICommercialContract GetCommercialContract()
        {
            var configuration = ConfigurationHelper.GetExecutingAssemblyConfig(this);
            var channelFactory = new ConfigurationChannelFactory<Service::ICommercialContract>("CommercialContractEndpoint", configuration, null); 
            return channelFactory.CreateChannel();
        }
    }
}