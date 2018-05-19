namespace Callboard.App.General.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public byte[] PhotoData { get; set; }

        public string PhotoMimeType { get; set; }
    }
}