using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Common.GetCategory;

namespace EndPoint.Site.Search.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetCategoryServices _getCategory;
        public Search(IGetCategoryServices getCategory)
        {
            _getCategory = getCategory;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _getCategory.Execute().Data);
        }
    }
}
