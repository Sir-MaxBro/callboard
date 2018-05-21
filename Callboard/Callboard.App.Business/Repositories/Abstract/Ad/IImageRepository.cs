using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface IImageRepository : IEntityRepository<Image>
    {
        IReadOnlyCollection<Image> GetImagesByAdId(int adId);
    }
}
