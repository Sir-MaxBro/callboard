using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Callboard.App.Web.Models;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _repository;
        public CategoryController(ICategoryRepository repository)
        {
            Checker.CheckForNull(repository);
            _repository = repository;
        }

        public PartialViewResult GetCategories()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _repository.GetCategories()
            };
            return PartialView("CategoryList", model);
        }

        [HttpPost]
        public PartialViewResult GetSubcategories(int categoryId, string returnUrl = null)
        {
            Checker.CheckId(categoryId, $"CategoryId in GetSubcategories method is not valid.");
            ViewBag.ReturnUrl = returnUrl;
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _repository.GetSubcategories(categoryId)
            };
            return PartialView("CategoryList", model);
        }
    }
}