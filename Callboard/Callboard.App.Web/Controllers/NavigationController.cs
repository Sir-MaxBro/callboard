using Callboard.App.Business.Services;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Models;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class NavigationController : Controller
    {
        private ICategoryService _categoryProvider;
        public NavigationController(ICategoryService categoryProvider)
        {
            if (categoryProvider == null)
            {
                throw new NullReferenceException(nameof(categoryProvider));
            }
            _categoryProvider = categoryProvider;
        }

        public ActionResult GetCategoryMenu()
        {
            var categoriesResult = _categoryProvider.GetMainCategories();
            if (categoriesResult.IsSuccess())
            {
                var categories = categoriesResult.GetSuccessResult();
                CategoryViewModel model = new CategoryViewModel { Categories = categories };
                return PartialView("CategoryMenu", model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult GetSubcategoryMenu(int categoryId)
        {
            var categoriesResult = _categoryProvider.GetSubcategories(categoryId);
            if (categoriesResult.IsSuccess())
            {
                var categories = categoriesResult.GetSuccessResult();
                CategoryViewModel model = new CategoryViewModel { Categories = categories };
                return PartialView("CategoryMenu", model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}