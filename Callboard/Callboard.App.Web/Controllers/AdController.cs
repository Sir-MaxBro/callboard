using Callboard.App.Business.Abstract;
using Callboard.App.General.Entities;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AdController : Controller
    {
        private IAdRepository _repository;
        public AdController(IAdRepository repository)
        {
            _repository = repository;
        }

        // GET: Home
        public ActionResult Index()
        {
            AdViewModel model = new AdViewModel
            {
                Ads = _repository.Items.ToList()
            };
            return View(model);
        }
    }
}