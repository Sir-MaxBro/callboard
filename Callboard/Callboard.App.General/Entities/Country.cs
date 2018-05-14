using System.Collections.Generic;
using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    [Table("Country")]
    public class Country
    {
        [Column("CountryId")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public ICollection<Area> Areas { get; set; }
    }
}
