using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Callboard.App.Web.Models
{
    public class AdDetailsViewModel
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int AdId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Kind { get; set; }

        [Required]
        public string State { get; set; }

        public IList<Image> Images { get; set; }

        public IList<Category> Categories { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Description { get; set; }

        public string AddressLine { get; set; }
    }
}