using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.ResultExtensions;
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
        private ICategoryService _categoryProvider;
        public CategoryController(ICategoryService categoryProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(categoryProvider);
            _categoryProvider = categoryProvider;
        }

        [AjaxOnly]
        public ActionResult GetAllCategories()
        {
            var categoriesResult = _categoryProvider.GetAll();
            if (categoriesResult.IsSuccess())
            {
                var categories = categoriesResult.GetSuccessResult();
                var categoriesData = JsonConvert.SerializeObject(categories);
                return Json(new { Categories = categoriesData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        public ActionResult GetEditCategories()
        {
            var categoriesResult = _categoryProvider.GetMainCategories();
            if (categoriesResult.IsSuccess())
            {
                var categories = categoriesResult.GetSuccessResult();
                return PartialView("EditCategoryList", categories);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        public ActionResult GetEditSubcategories(int categoryId)
        {
            var categoriesResult = _categoryProvider.GetSubcategories(categoryId);
            if (categoriesResult.IsSuccess())
            {
                var categories = categoriesResult.GetSuccessResult();
                return PartialView("EditCategoryList", categories);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
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
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteCategory(int categoryId)
        {
            var categoriesResult = _categoryProvider.Delete(categoryId);
            if (categoriesResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveCategory(string categoryData)
        {
            categoryData = categoryData ?? string.Empty;
            var category = JsonConvert.DeserializeObject<Category>(categoryData);
            if (category != null)
            {
                var categorySaveResult = _categoryProvider.Save(category);
                if (categorySaveResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}