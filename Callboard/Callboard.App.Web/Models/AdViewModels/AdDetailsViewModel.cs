using Callboard.App.General.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Callboard.App.Web.Models
{
    public class AdDetailsViewModel
    {
        public AdDetailsViewModel()
        {
            this.Location = new Location();
        }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int AdId { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Kind { get; set; }

        [Required]
        public string State { get; set; }

        public Image[] Images { get; set; }

        public Category[] Categories { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Description { get; set; }

        public string AddressLine { get; set; }
    }
}