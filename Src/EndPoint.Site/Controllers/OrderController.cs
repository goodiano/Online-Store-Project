using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Orders.Query.GetUserOrders;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IGetUserOrderServices _getUserOrder;
        public OrderController(IGetUserOrderServices getUserOrder)
        {
            _getUserOrder = getUserOrder;
        }
        public IActionResult Index()
        {
            int userId = ClaimUtitlity.GetUserId(User).Value;
            return View(_getUserOrder.Execute(userId).Data);
        }
    }
}
