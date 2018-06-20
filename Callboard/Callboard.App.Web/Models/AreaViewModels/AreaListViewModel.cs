using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class AreaListViewModel
    {
        public int CountryId { get; set; }

        public IReadOnlyCollection<Area> Areas { get; set; }
    }
}