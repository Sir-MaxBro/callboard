using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class CategoryViewModel
    {
        public IReadOnlyCollection<Category> Categories { get; set; }
    }
}