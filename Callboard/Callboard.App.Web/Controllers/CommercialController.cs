using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Callboard.App.Web.CommercialService;
using Callboard.App.Web.Models;

namespace Callboard.App.Web.Controllers
{
    public class CommercialController : Controller
    {

        // GET: Commercial
        public PartialViewResult GetCommercial()
        {
            ICommercialRepository commercialRepository = new CommercialRepositoryClient();

            var commercials = commercialRepository.GetCommercials();
            var model = new CommercialViewModel
            {
                Commercials = commercials
            };

            return PartialView("CommercialPartial", model);
        }

        //public async Task<ActionResult> RenderImage(int id)
        //{
        //    Item item = await db.Items.FindAsync(id);

        //    byte[] photoBack = item.InternalImage;

        //    return File(photoBack, "image/png");
        //}
    }
}