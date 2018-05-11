using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public byte[] PhotoData { get; set; }

        public string PhotoMimeType { get; set; }

        public ICollection<Mail> Emails { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}
