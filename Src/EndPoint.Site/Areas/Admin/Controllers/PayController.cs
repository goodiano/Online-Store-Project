using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Pay.Query.GetRequestPayForAdmin;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Operator")]
    public class PayController : Controller
    {
        private readonly IGetRequestPayForAdmin _payForAdmin;
        public PayController(IGetRequestPayForAdmin payForAdmin)
        {
            _payForAdmin = payForAdmin;
        }
        public IActionResult Index()
        {
            return View(_payForAdmin.Execute().Data);
        }
    }
}
