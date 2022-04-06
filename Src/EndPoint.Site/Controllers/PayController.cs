using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Carts;
using TemplateProjectOne.Application.Services.Pay.Command.AddRequestPay;

namespace EndPoint.Site.Controllers
{
    [Authorize("Customer")]
    public class PayController : Controller
    {
        private readonly IRequstPayServices _requstPay;
        private readonly ICartServices _cartServices;
        private readonly CookiesManager cookies;
        public PayController(IRequstPayServices requstPay, ICartServices cartServices)
        {
            _requstPay = requstPay;
            _cartServices = cartServices;
            cookies = new CookiesManager();
        }
        public IActionResult Index()
        {
            int? userId = ClaimUtitlity.GetUserId(User);
            var browserId = cookies.GetBrowserId(HttpContext);
            var cart = _cartServices.GetCart(browserId, userId);

            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _requstPay.Execute(_cartServices.GetCart(browserId, userId).Data.SumAmount, userId.Value);
                return Redirect($"https://sandbox.zarinpal.com");
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }

        }
    }
}
