using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateProjectOne.Application.Services.Users.Queries
{
    public interface IGetUsersService
    {
        ResultGetUserDto Excute(RequestGetUserDto request);
    }
}
