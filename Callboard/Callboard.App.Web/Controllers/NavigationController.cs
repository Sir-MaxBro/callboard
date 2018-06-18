using Callboard.App.Business.Services;
using Callboard.App.General.Helpers.Main;
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
        private IChecker _checker;
        public NavigationController(ICategoryService categoryProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(categoryProvider);
            _categoryProvider = categoryProvider;
        }

        public ActionResult GetMainCategories()
        {
            var categoriesResult = _categoryProvider.GetMainCategories();
            if (categoriesResult.IsSuccess())
            {
                var categories = categoriesResult.GetSuccessResult();
                CategoryViewModel model = new CategoryViewModel { Categories = categories };
                return PartialView("CategoryList", model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult GetSubcategories(int categoryId)
        {
            var categoriesResult = _categoryProvider.GetSubcategories(categoryId);
            if (categoriesResult.IsSuccess())
            {
                var categories = categoriesResult.GetSuccessResult();
                CategoryViewModel model = new CategoryViewModel { Categories = categories };
                return PartialView("CategoryList", model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}