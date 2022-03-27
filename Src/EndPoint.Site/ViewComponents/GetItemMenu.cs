using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Common.GetItemMenu;

namespace EndPoint.Site.ViewComponents
{
    public class GetItemMenu : ViewComponent
    {
        private readonly IGetItemMenuServices _getItem;
        public GetItemMenu(IGetItemMenuServices getItem)
        {
            _getItem = getItem;
        }

        public IViewComponentResult Invoke()
        {
            var menuItem = _getItem.Execute();
            return View(viewName: "GetItemMenu", menuItem.Data);
        }
    }
}
