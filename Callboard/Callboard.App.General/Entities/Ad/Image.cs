namespace Callboard.App.General.Entities
{
    public class Image
    {
        public int ImageId { get; set; }

        public int AdId { get; set; }

        public byte[] Data { get; set; }

        public string MimeType { get; set; }
    }
}