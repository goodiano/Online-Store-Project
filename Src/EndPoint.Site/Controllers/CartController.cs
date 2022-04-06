using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Carts;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartServices;
        CookiesManager cookies;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
            cookies = new CookiesManager();
        }
        public IActionResult Index()
        {
            var userId = ClaimUtitlity.GetUserId(User);
            var GetCart = _cartServices.GetCart(cookies.GetBrowserId(HttpContext),userId);
            return View(GetCart.Data);
        }

        public IActionResult Add(int cartItemId)
        {
            _cartServices.Add(cartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(int cartItemId)
        {
            _cartServices.LowOff(cartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(int productId)
        {
            var result = _cartServices.AddCart(productId, cookies.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }

        public IActionResult ProductRemove(int productId)
        {
            _cartServices.RemoveFromCart(productId, cookies.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
    }
}
