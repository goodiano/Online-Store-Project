using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Services.Product.Categories.Command;
using TemplateProjectOne.Application.Services.Product.Categories.Command.EditCategory;
using TemplateProjectOne.Application.Services.Product.Categories.Command.RemoveCategory;
using TemplateProjectOne.Application.Services.Product.Categories.Query.GetCategory;
namespace TemplateProjectOne.Application.Interfaces.FacadPattern
{
    public interface ICategoryFacadPattern
    {
        AddNewCategoriesServices AddNewCategoriesServices { get; }
        GetCategoryService GetCategoryService { get; }
        RemoveCategoryServices RemoveCategoryServices { get; }
        EditCategoryService EditCategoryService { get; }
    }
}

