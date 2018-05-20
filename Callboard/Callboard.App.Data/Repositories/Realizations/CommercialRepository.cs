using Callboard.App.General.Entities.Commercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Service = Callboard.App.Data.CommercialService;

namespace Callboard.App.Data.Repositories
{
    internal class CommercialRepository : ICommercialRepository
    {
        public IReadOnlyCollection<Commercial> Items => GetCommercials();

        private IReadOnlyCollection<Commercial> GetCommercials()
        {
            Service::ICommercialContract contract = new Service::CommercialContractClient();
            List<Commercial> commercials = null;
            try
            {
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
            catch(TimeoutException ex)
            {

            }
            catch(FaultException ex)
            {

            }
            catch (CommunicationException ex)
            {

            }
            catch(Exception ex)
            {

            }
            return commercials;
        }
    }
}
