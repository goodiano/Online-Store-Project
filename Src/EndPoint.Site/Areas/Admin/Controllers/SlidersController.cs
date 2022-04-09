using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectone.Application.Services.HomePages.Query.GetSliders;
using TemplateProjectOne.Application.Services.HomePages;
using TemplateProjectOne.Application.Services.HomePages.Command.DeleteSlider;
using TemplateProjectOne.Application.Services.HomePages.Command.EditSlider;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Operator")]
    public class SlidersController : Controller
    {
        private readonly IAddSliderServices _slider;
        private readonly IGetSliderServices _getSlider;
        private readonly IDeleteSliderServices _deleteSlider;
        private readonly IEditSliderServices _editSlider;
        public SlidersController
            (IAddSliderServices slider
            , IGetSliderServices getSlider
            , IDeleteSliderServices deleteSlider
            , IEditSliderServices editSlider)
        {
            _slider = slider;
            _getSlider = getSlider;
            _deleteSlider = deleteSlider;
            _editSlider = editSlider;
        }
        public IActionResult Index()
        {
            return View(_getSlider.Execute().Data);
        }

        public IActionResult AddSliders()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSliders(IFormFile file, string link, string title, string description)
        {
            var result = _slider.Execute(file, link, title, description);
            return View(result);
        }

        [HttpPost]
        public IActionResult RemoveSlider(int Id)
        {
            return Json(_deleteSlider.Execute(Id));
        }

        public IActionResult EditSlider(int Id, string link , string title , string description)
        {
            return Json(_editSlider.Execute(new RequestEditSliderDto
            {
                Id = Id,
                Link = link,
                Title = title,
                Description = description
            }));
        }
    }
}
