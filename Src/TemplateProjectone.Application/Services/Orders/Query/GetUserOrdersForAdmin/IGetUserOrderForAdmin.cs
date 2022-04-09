using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Orders;

namespace TemplateProjectOne.Application.Services.Orders.Query.GetUserOrdersForAdmin
{
    public interface IGetUserOrderForAdmin
    {
        RegisterDto<List<GetUserOrderForAdminDto>> Execute(OrderState orderState);
    }
}
