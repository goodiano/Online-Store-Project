using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Carts;

namespace EndPoint.Site.ViewComponents.Cart
{
    public class Cart:ViewComponent
    {
        private readonly ICartServices _cartServices;
        private readonly CookiesManager cookies;
        public Cart(ICartServices cartServices)
        {
            _cartServices = cartServices;
            cookies = new CookiesManager();
        }
        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtitlity.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartServices.GetCart(cookies.GetBrowserId(HttpContext) , userId).Data);
        }
    }
}
