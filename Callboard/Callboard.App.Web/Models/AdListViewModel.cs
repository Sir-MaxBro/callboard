using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class AdListViewModel
    {
        public IReadOnlyCollection<Ad> Ads { get; set; }
    }
}