using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
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

        public JsonResult GetAllCategories()
        {
            var categories = _categoryProvider.GetAll();
            var categoriesData = JsonConvert.SerializeObject(categories);
            return Json(new { Categories = categoriesData }, JsonRequestBehavior.AllowGet);
        }

        [Editor]
        public JsonResult GetMainCategories()
        {
            var categories = _categoryProvider.GetMainCategories();
            var categoriesData = JsonConvert.SerializeObject(categories);
            return Json(new { Categories = categoriesData }, JsonRequestBehavior.AllowGet);
        }

        [Editor]
        public JsonResult GetSubcategories(int categoryId)
        {
            var categories = _categoryProvider.GetSubcategories(categoryId);
            var categoriesData = JsonConvert.SerializeObject(categories);
            return Json(new { Categories = categoriesData }, JsonRequestBehavior.AllowGet);
        }

        [Editor]
        [HttpPost]
        public JsonResult SaveCategory(string categoryData)
        {
            bool isSaved = false;
            categoryData = categoryData ?? string.Empty;
            var category = JsonConvert.DeserializeObject<Category>(categoryData);
            if (category != null)
            {
                _categoryProvider.Save(category);
                isSaved = true;
            }
            return Json(new { isSaved = isSaved });
        }
    }
}