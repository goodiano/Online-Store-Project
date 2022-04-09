using TemplateProjectOne.Domain.Entities.Orders;

namespace TemplateProjectOne.Application.Services.Orders.Query.GetUserOrders
{
    public class GetUserOrderDto
    {
        public int OrderId { get; set; }
        public int RequestPayId { get; set; }
        public OrderState OrderState { get; set; }
        public List<GetUserOrderDetailDto> OrderDetailes { get; set; }
    }
}
