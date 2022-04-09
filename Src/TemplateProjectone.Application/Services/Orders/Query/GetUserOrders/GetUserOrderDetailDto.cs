namespace TemplateProjectOne.Application.Services.Orders.Query.GetUserOrders
{
    public class GetUserOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
