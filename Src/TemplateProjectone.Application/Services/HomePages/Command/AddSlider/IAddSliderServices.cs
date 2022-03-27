using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.HomePages
{
    public interface IAddSliderServices
    {
        RegisterDto Execute(IFormFile file, string link, string title, string description);
    }
}
