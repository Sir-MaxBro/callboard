using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    [Table("Location")]
    public class Location
    {
        [Column("LocationId")]
        public int Id { get; set; }

        //public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        //public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        //public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Column("AddressLine")]
        public string AddressLine { get; set; }
    }
}
