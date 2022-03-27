using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Users.Commands.ChangeActivityUser
{
    public interface IChangeActivityService
    {
        RegisterDto Execute(int Id);
    }
}
