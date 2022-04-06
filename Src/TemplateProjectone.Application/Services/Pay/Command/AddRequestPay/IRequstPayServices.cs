using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Pay.Command.AddRequestPay
{
    public interface IRequstPayServices
    {
        RegisterDto<RequestPayDto> Execute(decimal amount, int? userId);
    }
}
