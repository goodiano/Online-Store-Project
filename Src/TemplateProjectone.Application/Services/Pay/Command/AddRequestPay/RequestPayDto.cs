namespace TemplateProjectOne.Application.Services.Pay.Command.AddRequestPay
{
    public class RequestPayDto
    {
        public Guid guid { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public int RequestPayId { get; set; }
    }
}
