using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    [Table("City")]
    public class City
    {
        [Column("CityId")]
        public int Id { get; set; }

        [Column("AreaId")]
        public int AreaId { get; set; }

        //public Area Area { get; set; }
        [Column("CountryId")]
        public int CountryId { get; set; }

        //public Country Country { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
}
