using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class ImageViewModel
    {
        public IReadOnlyCollection<Image> Images { get; set; }
    }
}