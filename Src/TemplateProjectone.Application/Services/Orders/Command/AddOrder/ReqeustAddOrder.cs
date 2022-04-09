namespace TemplateProjectOne.Application.Services.Orders.Command.AddOrder
{
    public class ReqeustAddOrder
    {
        public int CartId { get; set; }
        public int RequestPayId { get; set; }
        public int UserId { get; set; }
        public string? Authority { get; set; }
        public int RefId { get; set; }
    }
}
