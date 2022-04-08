using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Orders.Query.GetUserOrders
{
    public interface IGetUserOrderServices
    {
        RegisterDto<List<GetUserOrderDto>> Execute(int UserId);
    }
}
