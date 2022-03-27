using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForSite
{
    public interface IGetDetailProductForSiteServices
    {
        RegisterDto<DetailProductForSiteDto> Execute(int Id);
    }
}
