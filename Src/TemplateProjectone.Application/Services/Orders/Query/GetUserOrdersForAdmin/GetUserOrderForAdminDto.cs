using TemplateProjectOne.Domain.Entities.Orders;

namespace TemplateProjectOne.Application.Services.Orders.Query.GetUserOrdersForAdmin
{
    public class GetUserOrderForAdminDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public OrderState OrderState { get; set; }
        public int RequestId { get; set; }
        public int CountProduct { get; set; }

    }
}
