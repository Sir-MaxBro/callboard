using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class AdDetailsViewModel
    {
        public int AdId { get; set; }

        public int LocationId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public string Kind { get; set; }

        public string State { get; set; }

        public IList<Image> Images { get; set; }

        public IList<Category> Categories { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

        public string AddressLine { get; set; }
    }
}