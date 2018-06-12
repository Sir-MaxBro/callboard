using System.Collections.Generic;

namespace Callboard.App.General.Entities.Data
{
    public class SearchConfiguration
    {
        public string Name { get; set; }

        public string State { get; set; }

        public string Kind { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public int CountryId { get; set; }

        public int AreaId { get; set; }

        public int CityId { get; set; }

        public IReadOnlyCollection<Category> Categories { get; set; }
    }
}