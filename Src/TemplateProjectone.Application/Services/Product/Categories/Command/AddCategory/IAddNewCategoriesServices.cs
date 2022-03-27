using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Categories.Command
{
    public interface IAddNewCategoriesServices
    {
        RegisterDto Execute(int? parentId, string name);
    }
}
