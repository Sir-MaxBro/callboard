using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class SearchViewModel
    {
        public IReadOnlyCollection<Ad> Ads { get; set; }

        public SearchConfiguration SearchConfiguration { get; set; }
    }
}