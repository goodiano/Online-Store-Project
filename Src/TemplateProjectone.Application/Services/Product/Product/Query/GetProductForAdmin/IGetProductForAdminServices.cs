using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForAdmin
{
    public interface IGetProductForAdminServices
    {
        RegisterDto<AllProductDto> Execute(int Page = 1, int PageSize = 20);
    }
}
