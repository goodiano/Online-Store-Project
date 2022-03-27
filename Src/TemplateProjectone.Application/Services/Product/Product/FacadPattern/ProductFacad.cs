using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Product.Product.Command;
using TemplateProjectOne.Application.Services.Product.Product.Command.EditProduct;
using TemplateProjectOne.Application.Services.Product.Product.Command.RemoveProduct;
using TemplateProjectOne.Application.Services.Product.Product.Query;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetAllCategories;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForAdmin;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForAdmin;

namespace TemplateProjectOne.Application.Services.Product.Product.FacadPattern
{
    public class ProductFacad : IProductFacadPattern
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _env;
        public ProductFacad(IDataBaseContext context , IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        private AddProductServices _addProductServices;
        public AddProductServices AddProductServices 
        {
            get
            {
               return _addProductServices = _addProductServices ?? new AddProductServices(_context , _env);
            }
                
        }

        private GetAllCategoriesServices _getAllCategoriesServices;
        public GetAllCategoriesServices GetAllCategoriesServices
        {
            get
            {
                return _getAllCategoriesServices = _getAllCategoriesServices ?? new GetAllCategoriesServices(_context);
            }
        }

        private GetProductForAdminServices _getProductForAdminServices;
        public GetProductForAdminServices GetProductForAdminServices
        {
            get
            {
                return _getProductForAdminServices = _getProductForAdminServices ?? new GetProductForAdminServices(_context);
            }
        }

        private GetDetailProductServices _getDetailProductServices;
        public GetDetailProductServices GetDetailProductServices
        {
            get
            {
                return _getDetailProductServices = _getDetailProductServices ?? new GetDetailProductServices(_context);
            }
        }

        private RemoveProductServices _removeProductServices;
        public RemoveProductServices RemoveProductServices
        {
            get
            {
                return _removeProductServices = _removeProductServices ?? new RemoveProductServices(_context);
            }
        }

        private EditProductServices _editProductServices;
        public EditProductServices EditProductServices
        {
            get
            {
                return _editProductServices = _editProductServices ?? new EditProductServices(_context);
            }
        }
    }
}
