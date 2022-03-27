using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectone.Application.Services.HomePages.Command.AddHomePageImages
{
    public interface IAddHomePageImageServices
    {
        RegisterDto Execute(AddHomePageImageRequestDto request);
    }
}