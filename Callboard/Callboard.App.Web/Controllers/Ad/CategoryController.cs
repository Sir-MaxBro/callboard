using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Models;
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

        public PartialViewResult GetCategories()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _categoryProvider.GetAll()
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