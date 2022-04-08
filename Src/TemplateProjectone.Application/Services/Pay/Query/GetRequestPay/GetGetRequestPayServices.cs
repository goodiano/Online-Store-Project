using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Pay.Query.GetRequestPay
{
    public class GetRequestPayServices : IGetRequestPayServices
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<GetRequestPayDto> Execute(Guid guid)
        {
            var res = _context.RequestPay.Where(p => p.Guid == guid).FirstOrDefault();
            if(res != null)
            {
                return new RegisterDto<GetRequestPayDto>
                {
                    Data = new GetRequestPayDto
                    {
                        Id = res.Id,
                        Amount = res.Amount
                    },
                    IsSuccess = true,
                };
            }
            else
            {
                return new RegisterDto<GetRequestPayDto>
                {
                    Data = new GetRequestPayDto
                    {
                        Amount = 0
                    },
                    IsSuccess = false,
                };
            }
        }
    }
}
