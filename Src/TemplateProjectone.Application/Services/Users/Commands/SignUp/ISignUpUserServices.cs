using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Users.Commands.SignUp
{
    public interface ISignUpUserServices
    {
        RegisterDto<RegisterUserDto> Ecexute(RequestRegisterUserDto request);
    }
}