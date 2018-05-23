using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class AreaRepository : EntityRepository, IAreaRepository
    {
        private const string TABLE_NAME = "Area";
        public AreaRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        IReadOnlyCollection<Area> IEntityRepository<Area>.Items => throw new NotImplementedException();

        public IReadOnlyCollection<Area> GetAreasByCountryId(int countryId)
        {
            IReadOnlyCollection<Area> areas = base.GetEntities<Area>("selectByCountryId", MapArea, countryId);
            return areas;
        }

        private Area MapArea(DbDataReader reader)
        {
            return new Area
            {
                AreaId = Mapper.MapProperty<int>(reader, "AreaId", base.GetName),
                CountryId = Mapper.MapProperty<int>(reader, "CountryId", base.GetName),
                Name = Mapper.MapProperty<string>(reader, "Name", base.GetName)
            };
        }
    }
}
