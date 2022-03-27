using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModel.HomePages;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TemplateProjectone.Application.Services.HomePages.Query.GetSliders;
using TemplateProjectOne.Application.Services.Common.GetHomePageImages;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderServices _getSlider;
        private readonly IGetHomePageImageServices _getHomePageImage;

        public HomeController(
            ILogger<HomeController> logger , 
            IGetSliderServices getSlider,
            IGetHomePageImageServices getHomePageImage
            )
        {
            _logger = logger;
            _getSlider = getSlider;
            _getHomePageImage = getHomePageImage;
           
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSlider.Execute().Data,
                PageImage = _getHomePageImage.Execute().Data
            };

            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}