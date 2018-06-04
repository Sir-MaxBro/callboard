using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class SearchViewModel
    {
        public IReadOnlyCollection<Ad> Ads { get; set; }
    }
}