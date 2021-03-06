﻿using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext
{
    public interface IAreaContext
    {
        IResult<IReadOnlyCollection<Area>> GetAll();

        IResult<Area> GetById(int id);

        IResult<Area> Save(int countryId, Area obj);

        IResult<Area> Delete(int id);

        IResult<IReadOnlyCollection<Area>> GetAreasByCountryId(int countryId);
    }
}