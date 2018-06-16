using Callboard.App.Business.Services;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Models;
using System;
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