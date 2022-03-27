using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Product.Categories.Command.EditCategory;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryFacadPattern _categoryFacadPattern;
        public CategoriesController(ICategoryFacadPattern categoryFacadPattern)
        {
            _categoryFacadPattern = categoryFacadPattern;
        }

        public IActionResult Index(int? parentId)
        {
            return View(_categoryFacadPattern.GetCategoryService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult Category(int? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult Category(int? parentId, string Name)
        {
            var category = _categoryFacadPattern.AddNewCategoriesServices.Execute(parentId, Name);
            return Json(category);
        }

        public IActionResult RemoveCategory(int Id)
        {
            var categoryRemove = _categoryFacadPattern.RemoveCategoryServices.Execute(Id);
            return Json(categoryRemove);
        }

        [HttpPost]
        public IActionResult EditCategory(int id, string name)
        {
            return Json(_categoryFacadPattern.EditCategoryService.Execute
                (new RequestEditCategoryDto
                {
                    Id = id,
                    Name = name
                }));
        }
    }
}
