using Callboard.App.Data.ServiceContext;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using Callboard.App.General.Results.Realizations;
using System.Collections.Generic;
using System.Linq;
using Service = Callboard.App.Data.CommercialService;

namespace Callboard.App.Data.DataContext.Realizations.Service
{
    internal class CommercialServiceContext : EntityServiceContext<Service::ICommercialContract>, ICommercialContext
    {
        public CommercialServiceContext(IServiceContext<Service::ICommercialContract> context)
            : base(context) { }

        public IResult<IReadOnlyCollection<Commercial>> GetCommercials()
        {
            IReadOnlyCollection<Commercial> commercials = null;
            IResult<IReadOnlyCollection<Commercial>> result = new NoneResult<IReadOnlyCollection<Commercial>>();

            commercials = base.GetData("CommercialContractEndpoint", null, this.GetCommercials);
            if (commercials != null)
            {
                result = new SuccessResult<IReadOnlyCollection<Commercial>>(commercials);
            }

            return result;
        }

        private IReadOnlyCollection<Commercial> GetCommercials(Service::ICommercialContract contract)
        {
            return contract.GetCommercials()?.Select(MapCommercial).ToList();
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