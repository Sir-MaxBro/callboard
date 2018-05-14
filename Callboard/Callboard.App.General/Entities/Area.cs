using System.Collections.Generic;
using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    [Table("Area")]
    public class Area
    {
        [Column("AreaId")]
        public int Id { get; set; }

        [Column("CountryId")]
        public int CountryId { get; set; }

        //public Country Country { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
