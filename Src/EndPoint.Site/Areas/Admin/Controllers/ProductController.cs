using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Product.Product.Command.EditProduct;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductFacadPattern _productFacad;
        public ProductController(IProductFacadPattern productFacad)
        {
            _productFacad = productFacad;
        }


        public IActionResult Index(int Page = 1, int PageSize = 20)
        {
            return View(_productFacad.GetProductForAdminServices.Execute(Page, PageSize).Data);
        }


        public IActionResult Detail(int Id)
        {
            return View(_productFacad.GetDetailProductServices.Execute(Id).Data);
        }

        public IActionResult RemoveProduct(int Id)
        {
            var product = _productFacad.RemoveProductServices.Execute(Id);
            return Json(product);
        }

        [HttpPost]
        public IActionResult EditProduct(int Id, string Name, string Brand, decimal Price, int Inventory, bool ShowOnSite, string Description)
        {
            return Json(_productFacad.EditProductServices.Execute
                (new RequestEditProductDto
                {
                    Id = Id,
                    Name = Name,
                    Brand = Brand,
                    Price = Price,
                    Inventory = Inventory,
                    ShowOnSite = ShowOnSite,
                    Description = Description,
                }));
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesServices.Execute().Data, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult AddNewProduct(RequestAddProductDto request, List<FeatureDto> features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }

            request.Images = images;
            request.FeatureDto = features;
            return Json(_productFacad.AddProductServices.Excute(request));
        }
    }
}
