
using TemplateProjectone.Application.Services.HomePages.Query.GetSliders;
using TemplateProjectOne.Application.Services.Common.GetHomePageImages;

namespace EndPoint.Site.Models.ViewModel.HomePages
{
    public class HomePageViewModel
    {
        public List<GetSliderDto> Sliders { get; set; }
        public List<GetHomePageImageDto> PageImage { get; set; }
    }
}
