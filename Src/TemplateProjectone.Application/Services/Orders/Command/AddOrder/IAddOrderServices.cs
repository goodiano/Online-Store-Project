using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Orders.Command.AddOrder
{
    public interface IAddOrderServices
    {
        RegisterDto Execute(ReqeustAddOrder reqeust);
    }
}
