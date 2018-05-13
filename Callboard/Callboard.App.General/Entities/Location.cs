namespace Callboard.App.General.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public int AreaId { get; set; }

        public int CountryId { get; set; }

        public string AddressLine { get; set; }
    }
}
