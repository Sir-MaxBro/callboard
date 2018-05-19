using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Data.Abstract
{
    public interface IAdRepository : IEntityRepository<Ad>
    {
        Ad GetAd(int id);

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);
    }
}
