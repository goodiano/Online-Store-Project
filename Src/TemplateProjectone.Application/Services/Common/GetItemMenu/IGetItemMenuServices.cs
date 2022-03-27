using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Common.GetItemMenu
{
    public interface IGetItemMenuServices
    {
        RegisterDto<List<ItemMenuDto>> Execute();
    }
}
