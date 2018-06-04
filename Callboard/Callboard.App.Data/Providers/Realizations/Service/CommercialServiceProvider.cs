using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using Callboard.App.Data.Providers.Main;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Loggers.Main;
using Service = Callboard.App.Data.CommercialService;

namespace Callboard.App.Data.Providers.Realizations.Service
{
    internal class CommercialServiceProvider : ICommercialProvider
    {
        private ILoggerWrapper _logger;
        public CommercialServiceProvider(ILoggerWrapper logger)
        {
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }

        public IReadOnlyCollection<Commercial> GetCommercials()
        {
            IReadOnlyCollection<Commercial> commercials = null;
            try
            {
                Service::ICommercialContract contract = new Service::CommercialContractClient();
                commercials = contract.GetCommercials().Select(MapCommercial).ToList();
            }
            catch (ConfigurationErrorsException ex)
            {
                _logger.ErrorFormat($"{ ex.Message }");
            }
            catch (TimeoutException ex)
            {
                _logger.ErrorFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
            }
            catch (FaultException<Service::CommercialNotFound> ex)
            {
                _logger.ErrorFormat($"{ ex.Message }");
            }
            catch (FaultException ex)
            {
                _logger.ErrorFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
            }
            catch (CommunicationException ex)
            {
                _logger.ErrorFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
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
    }
}