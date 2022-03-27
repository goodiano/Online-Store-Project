using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.HomePages.Command.EditSlider
{
    public interface IEditSliderServices
    {
        RegisterDto Execute(RequestEditSliderDto request);
    }
}
