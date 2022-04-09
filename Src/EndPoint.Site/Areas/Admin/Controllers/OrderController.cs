using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateProjectOne.Application.Services.Orders.Query.GetUserOrdersForAdmin;
using TemplateProjectOne.Domain.Entities.Orders;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Operator")]
    public class OrderController : Controller
    {
        private readonly IGetUserOrderForAdmin _getUserOrder;
        public OrderController(IGetUserOrderForAdmin getUserOrder)
        {
            _getUserOrder = getUserOrder;
        }
        public IActionResult Index(OrderState orderState)
        {
            return View(_getUserOrder.Execute(orderState).Data);
        }
    }
}
