using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CategoryController : Controller
    {
        private IChecker _checker;
        private ICategoryProvider _categoryProvider;
        public CategoryController(ICategoryProvider categoryProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(categoryProvider);
            _categoryProvider = categoryProvider;
        }

        public JsonResult GetCategories()
        {
            var categories = _categoryProvider.GetAll();
            var categoriesData = JsonConvert.SerializeObject(categories);
            return Json(new { Categories = categoriesData }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetMainCategories()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _categoryProvider.GetMainCategories()
            };
            return PartialView("CategoryList", model);
        }

        public PartialViewResult GetSubcategories(int categoryId)
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _categoryProvider.GetSubcategories(categoryId)
            };
            return PartialView("CategoryList", model);
        }
    }
}