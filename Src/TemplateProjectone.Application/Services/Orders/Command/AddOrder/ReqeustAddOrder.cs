namespace TemplateProjectOne.Application.Services.Orders.Command.AddOrder
{
    public class ReqeustAddOrder
    {
        public int CartId { get; set; }
        public int RequestPayId { get; set; }
        public int UserId { get; set; }
    }
}
