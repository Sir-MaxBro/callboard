using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Net;
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

        public ActionResult GetAllCategories()
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var categories = _categoryProvider.GetAll();
            var categoriesData = JsonConvert.SerializeObject(categories);
            return Json(new { Categories = categoriesData }, JsonRequestBehavior.AllowGet);
        }

        [Editor]
        public PartialViewResult GetEditCategories()
        {
            var categories = _categoryProvider.GetMainCategories();
            return PartialView("EditCategoryList", categories);
        }

        [Editor]
        public PartialViewResult GetEditSubcategories(int categoryId)
        {
            var categories = _categoryProvider.GetSubcategories(categoryId);
            return PartialView("EditCategoryList", categories);
        }

        [Editor]
        public PartialViewResult CreateSubcategory(int parentId)
        {
            var category = new Category
            {
                ParentId = parentId
            };
            return PartialView("EditCategory", category);
        }

        [Editor]
        [HttpPost]
        public ActionResult DeleteCategory(int categoryId)
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            _categoryProvider.Delete(categoryId);
            return Json(new { IsDeleted = true });
        }

        [Editor]
        [HttpPost]
        public ActionResult SaveCategory(string categoryData)
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

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