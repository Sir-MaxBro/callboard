using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Callboard.Service.Commercial.Config;

namespace Callboard.Service.Commercial
{
    public class CommercialRepository : ICommercialRepository
    {
        public IReadOnlyCollection<Commercial> GetCommercials()
        {
            var section = ((StartupCommercialConfigSection)ConfigurationManager.GetSection("commercialSettings")).Pathways;

            return null;
        }
    }
}
