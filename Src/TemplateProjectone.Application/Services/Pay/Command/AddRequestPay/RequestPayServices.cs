using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Fainance;

namespace TemplateProjectOne.Application.Services.Pay.Command.AddRequestPay
{
    public class RequestPayServices : IRequstPayServices
    {
        private readonly IDataBaseContext _context;
        public RequestPayServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<RequestPayDto> Execute(decimal amount, int? userId)
        {
            var user = _context.Users.Find(userId);
            RequestPay pay = new RequestPay()
            {
                Amount = amount,
                Guid = Guid.NewGuid(),
                isPay = false,
                User = user,
            };

            _context.RequestPay.Add(pay);
            _context.SaveChanges();



            return new RegisterDto<RequestPayDto>
            {
                Data = new RequestPayDto
                {
                    guid = pay.Guid,
                    Amount = pay.Amount,
                    Email = user.Email,
                    RequestPayId = pay.Id
                },
                IsSuccess = true
            };
        }

       
    }
}
