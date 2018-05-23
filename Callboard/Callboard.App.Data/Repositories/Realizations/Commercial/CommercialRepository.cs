using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Loggers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using Service = Callboard.App.Data.CommercialService;

namespace Callboard.App.Data.Repositories
{
    internal class CommercialRepository : ICommercialRepository
    {
        private ILoggerWrapper _logger = LoggerWrapper.GetInstance();

        public IReadOnlyCollection<Commercial> GetCommercials()
        {
            List<Commercial> commercials = null;
            try
            {
                Service::ICommercialContract contract = new Service::CommercialContractClient();
                Func<Service::Commercial, Commercial> mapper = commercial =>
                {
                    var resCommercial = new Commercial
                    {
                        Image = new Image
                        {
                            Data = commercial.Image.Data,
                            Extension = commercial.Image.Extension
                        }
                    };
                    return resCommercial;
                };
                commercials = contract.GetCommercials().Select(mapper).ToList();
            }
            catch (ConfigurationErrorsException ex)
            {
                _logger.ErrorFormat($"{ ex.Message }");
            }
            catch (TimeoutException ex)
            {
                _logger.ErrorFormat($"Cannot connect to CommercialContractClient.\n { ex.Message }");
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
    }
}
