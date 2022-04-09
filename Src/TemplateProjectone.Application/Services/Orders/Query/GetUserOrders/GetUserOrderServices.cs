using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Orders.Query.GetUserOrders
{
    public class GetUserOrderServices : IGetUserOrderServices
    {
        private readonly IDataBaseContext _context;
        
        public GetUserOrderServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<GetUserOrderDto>> Execute(int UserId)
        {
            var orders = _context.Order
                .Include(p => p.OrderDetails)
                .ThenInclude(P => P.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id).ToList().Select(p => new GetUserOrderDto
                {
                    OrderId = p.Id,
                    OrderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetailes = p.OrderDetails.Select(s=> new GetUserOrderDetailDto
                    {
                        OrderDetailId = s.Id,
                        ProductName = s.Product.Name,
                        Count = s.Count,
                        Price = s.Price,
                        ProductId = s.ProductId
                    }).ToList(),
                }).ToList();


            return new RegisterDto<List<GetUserOrderDto>>
            {
                Data = orders,
                IsSuccess = true,
            };
                
        }
    }
}
