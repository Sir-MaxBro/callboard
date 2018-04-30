using Callboard.App.Business.Abstract;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class NavController : Controller
    {
        private ICategoryRepository _repository;
        public NavController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        // GET: Nav
        public PartialViewResult Menu()
        {
            NavViewModel model = new NavViewModel
            {
                Categories = _repository.Items
            };
            return PartialView(model);
        }
    }
}