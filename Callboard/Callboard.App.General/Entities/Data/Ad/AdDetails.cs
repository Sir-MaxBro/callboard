namespace Callboard.App.General.Entities
{
    public class AdDetails : Ad
    {
        public User User { get; set; }

        public string Description { get; set; }

        public string AddressLine { get; set; }
    }
}