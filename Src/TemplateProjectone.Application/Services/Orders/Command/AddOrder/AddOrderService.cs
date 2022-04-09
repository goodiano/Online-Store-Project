using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Domain.Entities.Orders;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Orders.Command.AddOrder
{
    public class AddOrderService : IAddOrderServices
    {
        private readonly IDataBaseContext _context;

        public AddOrderService(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(ReqeustAddOrder reqeust)
        {
            var cart = _context.Cart
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .Where(p => p.Id == reqeust.CartId)
                .FirstOrDefault();

            var requestPay = _context.RequestPay.Find(reqeust.RequestPayId);
            var user = _context.Users.Find(reqeust.UserId);

            requestPay.isPay = true;
            requestPay.DatePay = DateTime.Now;
            requestPay.Authority = reqeust.Authority;
            requestPay.RefId = reqeust.RefId;
            cart.Finished = true;

            Order order = new Order()
            {
                Address = " ",
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user,
            };
            _context.Order.Add(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (var item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    Price = ((int)item.Product.Price),
                    Product = item.Product,
                    Order = order
                };
                orderDetails.Add(orderDetail);
            }

            _context.OrderDetail.AddRange(orderDetails);
            _context.SaveChanges();
            return new RegisterDto
            {
                IsSuccess = true,
                Message = "پرداخت با موفقیت انجام شد"
            };

        }
    }
}
