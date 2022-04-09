namespace TemplateProjectOne.Application.Services.Pay.Query.GetRequestPayForAdmin
{
    public class RequestPayForAdminDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public bool isPay { get; set; }
        public DateTime? DatePay { get; set; }
        public string Authority { get; set; } = " ";
        public long RefId { get; set; } = 0;
    }
}
