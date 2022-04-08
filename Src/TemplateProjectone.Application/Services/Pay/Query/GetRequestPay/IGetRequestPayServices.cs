using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Pay.Query.GetRequestPay
{
    public interface IGetRequestPayServices
    {
        RegisterDto<GetRequestPayDto> Execute(Guid guid);
    }
}
