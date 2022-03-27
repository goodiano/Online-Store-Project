using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Services.Product.Product.Command;
using TemplateProjectOne.Application.Services.Product.Product.Command.EditProduct;
using TemplateProjectOne.Application.Services.Product.Product.Command.RemoveProduct;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetAllCategories;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForAdmin;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForAdmin;

namespace TemplateProjectOne.Application.Interfaces.FacadPattern
{
    public interface IProductFacadPattern
    {
        AddProductServices AddProductServices { get; }
        GetAllCategoriesServices GetAllCategoriesServices { get; }

        /// <summary>
        /// لیست محصولات در صفحه ادمین
        /// </summary>
        GetProductForAdminServices GetProductForAdminServices { get; }
        GetDetailProductServices GetDetailProductServices { get; }
        RemoveProductServices RemoveProductServices { get; }
        EditProductServices EditProductServices { get; }

    }
}
