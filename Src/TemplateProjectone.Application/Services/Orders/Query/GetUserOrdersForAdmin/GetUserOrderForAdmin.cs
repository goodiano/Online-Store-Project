using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Orders;

namespace TemplateProjectOne.Application.Services.Orders.Query.GetUserOrdersForAdmin
{
    public class GetUserOrderForAdmin : IGetUserOrderForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetUserOrderForAdmin(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<GetUserOrderForAdminDto>> Execute(OrderState orderState)
        {
            var orders = _context.Order
                .Include(p => p.OrderDetails)
                .Where(p => p.OrderState == orderState)
                .OrderByDescending(p => p.Id)
                .ToList()
                .Select(p => new GetUserOrderForAdminDto()
                {
                    UserId = p.UserId,
                    CountProduct = p.OrderDetails.Count,
                    InsertDate = p.InsertTime,
                    OrderId = p.Id,
                    OrderState = p.OrderState,
                    RequestId = p.RequestPayId
                }).ToList();


            return new RegisterDto<List<GetUserOrderForAdminDto>>
            {
                Data = orders,
                IsSuccess = true
            };
        }
    }
}
