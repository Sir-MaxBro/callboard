namespace Callboard.App.General.Entities
{
    public class Location
    {
        public int Id { get; set; }

        //public int CityId { get; set; }

        public City City { get; set; }

        //public int AreaId { get; set; }

        public Area Area { get; set; }

        //public int CountryId { get; set; }

        public Country Country { get; set; }

        public string AddressLine { get; set; }
    }
}
