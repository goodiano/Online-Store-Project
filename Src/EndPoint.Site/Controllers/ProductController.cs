using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Product.Product.FacadPattern;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForSite;

namespace EndPoint.Site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductForSiteFacadPattern _productFacad;
        public ProductController(IProductForSiteFacadPattern ProductFacad)
        {
            _productFacad = ProductFacad;
        }
        public IActionResult Index(Ordering ordering, string SearchKey , int page = 1, int? CatId = null)
        {
            return View(_productFacad.GetProductForSiteServices.Execute(ordering, SearchKey , page, CatId).Data);
        }

        public IActionResult Detail(int Id)
        {
            return View(_productFacad.GetDetailProductForSiteServices.Execute(Id).Data);
        }
    }
}
