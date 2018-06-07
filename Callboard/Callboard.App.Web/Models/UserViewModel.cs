using Callboard.App.General.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Callboard.App.Web.Models
{
    public class UserViewModel
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public byte[] PhotoData { get; set; }

        public string PhotoExtension { get; set; }

        public IList<Phone> Phones { get; set; }

        public IList<Mail> Mails { get; set; }
    }
}