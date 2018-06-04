using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public byte[] PhotoData { get; set; }

        public string PhotoExtension { get; set; }

        public IReadOnlyCollection<Phone> Phones { get; set; }

        public IReadOnlyCollection<Mail> Mails { get; set; }
    }
}