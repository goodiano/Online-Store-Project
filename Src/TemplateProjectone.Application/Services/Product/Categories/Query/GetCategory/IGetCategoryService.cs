using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Product;

namespace TemplateProjectOne.Application.Services.Product.Categories.Query.GetCategory
{
    public interface IGetCategoryService
    {
        RegisterDto<List<GetCategoryDto>> Execute(int? ParentId);
    }
}
