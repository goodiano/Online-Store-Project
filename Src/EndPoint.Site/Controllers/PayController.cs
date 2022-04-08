using Dto.Payment;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Carts;
using TemplateProjectOne.Application.Services.Orders.Command.AddOrder;
using TemplateProjectOne.Application.Services.Pay.Command.AddRequestPay;
using TemplateProjectOne.Application.Services.Pay.Query.GetRequestPay;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IRequstPayServices _requstPay;
        private readonly ICartServices _cartServices;
        private readonly CookiesManager cookies;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IGetRequestPayServices _payServices;
        private readonly IAddOrderServices _addOrder;
        public PayController(IRequstPayServices requstPay, ICartServices cartServices , IGetRequestPayServices payServices , IAddOrderServices addOrder)
        {
            _requstPay = requstPay;
            _cartServices = cartServices;
            cookies = new CookiesManager();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _payServices = payServices;
            _addOrder = addOrder;
        }
        public async Task<IActionResult> Index()
        {
            int? userId = ClaimUtitlity.GetUserId(User);
            var browserId = cookies.GetBrowserId(HttpContext);
            var cart = _cartServices.GetCart(browserId, userId);

            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _requstPay.Execute(_cartServices.GetCart(browserId, userId).Data.SumAmount, userId.Value);

                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    CallbackUrl = $"https://localhost:44379/Pay/Verify?guid={requestPay.Data.guid}",
                    Description = "پرداخت فاکتور شماره:" + requestPay.Data.RequestPayId,
                    Email = $"{requestPay.Data.Email}",
                    Amount = ((int)requestPay.Data.Amount),
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");

            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }

        }

        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {
            var requestPays = _payServices.Execute(guid);
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = ((int)requestPays.Data.Amount),
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);

            int? userId = ClaimUtitlity.GetUserId(User);
            var cart = _cartServices.GetCart(cookies.GetBrowserId(HttpContext), userId);
            
            if (verification.Status == 100)
            {
                var res = _addOrder.Execute(new ReqeustAddOrder
                {
                    CartId = cart.Data.CartId,
                    RequestPayId = requestPays.Data.Id,
                    UserId = userId.Value
                });

                return RedirectToAction("Index", "Order");
            }
            else
            {

            }

            return View();

        }
    }
}
