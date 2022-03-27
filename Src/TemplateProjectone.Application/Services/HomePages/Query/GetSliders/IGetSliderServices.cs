using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectone.Application.Services.HomePages.Query.GetSliders
{
    public interface IGetSliderServices
    {
        RegisterDto<List<GetSliderDto>> Execute();
    }
} 
