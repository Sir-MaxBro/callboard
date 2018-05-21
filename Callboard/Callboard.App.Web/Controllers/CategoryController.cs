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

        public PartialViewResult GetCategoryList()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _repository.Items
            };
            return PartialView("CategoryList", model);
        }

        public PartialViewResult GetSubcategories(int categoryId)
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _repository.GetSubcategories(categoryId)
            };
            return PartialView("CategoryList", model);
        }
    }
}