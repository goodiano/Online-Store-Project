using Microsoft.AspNetCore.Mvc;
using TemplateProjectone.Application.Services.HomePages.Command.AddHomePageImages;
using TemplateProjectOne.Domain.Entities.Product.HomePages.HomePageImages;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImageController : Controller
    {
        private readonly IAddHomePageImageServices _addHomePageImage;
        public HomePageImageController(IAddHomePageImageServices addHomePageImage)
        {
            _addHomePageImage = addHomePageImage;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(int Id , string src , string link , string title , string description , IFormFile file, LocationImages locationImages , decimal price)
        {
            var result = _addHomePageImage.Execute(new AddHomePageImageRequestDto
            {
                Id = Id,
                Src = src,
                Link = link,
                Title = title,
                Description = description,
                file = file,
                LocationImages = locationImages,
                Price = price
            });
            return View();
        }
    }
}
