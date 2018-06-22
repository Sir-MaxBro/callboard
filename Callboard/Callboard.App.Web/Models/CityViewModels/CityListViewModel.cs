using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class CityListViewModel
    {
        public int AreaId { get; set; }

        public IReadOnlyCollection<City> Cities { get; set; }
    }
}