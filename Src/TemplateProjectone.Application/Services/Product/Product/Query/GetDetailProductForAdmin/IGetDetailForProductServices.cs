using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForAdmin
{
    public interface IGetDetailForProductServices
    {
        RegisterDto<DetailProductDto> Execute(int Id);
    }
}
