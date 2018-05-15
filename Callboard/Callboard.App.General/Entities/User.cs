using System;
using System.Collections.Generic;
using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    [Table("User")]
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("PhotoData")]
        public byte[] PhotoData { get; set; }

        [Column("PhotoMimeType")]
        public string PhotoMimeType { get; set; }

        public ICollection<Mail> Emails { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}
