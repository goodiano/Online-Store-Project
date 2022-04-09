using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Pay.Query.GetRequestPayForAdmin
{
    public class GetRequestPayForAdmin : IGetRequestPayForAdmin
    {
        private readonly IDataBaseContext _context;

        public GetRequestPayForAdmin(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<RequestPayForAdminDto>> Execute()
        {
            var pay = _context.RequestPay
                .Include(p => p.User)
                .ToList()
                .Select(p => new RequestPayForAdminDto()
                {
                    Amount = p.Amount,
                    DatePay = p.DatePay,
                    Guid = p.Guid,
                    isPay = p.isPay,
                    UserId = p.User.Id,
                    UserName = p.User.Name,
                    Authority = p.Authority,
                    RefId = p.RefId,
                }).ToList();

            return new RegisterDto<List<RequestPayForAdminDto>>
            {
                Data = pay,
                IsSuccess = true
            };
        }
    }
}
