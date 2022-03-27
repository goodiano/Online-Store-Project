using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Product.Categories.Command;
using TemplateProjectOne.Application.Services.Product.Categories.Command.EditCategory;
using TemplateProjectOne.Application.Services.Product.Categories.Command.RemoveCategory;
using TemplateProjectOne.Application.Services.Product.Categories.Query.GetCategory;

namespace TemplateProjectOne.Application.Services.Product.Categories.FasadPattern
{
    public class CategoryFasad : ICategoryFacadPattern
    {
        private readonly IDataBaseContext _context;
        public CategoryFasad(IDataBaseContext context)
        {
            _context = context;
        }


        private AddNewCategoriesServices _addNewCategoriesServices;
        public AddNewCategoriesServices AddNewCategoriesServices
        {
            get
            {
                return _addNewCategoriesServices = _addNewCategoriesServices ?? new AddNewCategoriesServices(_context);
            }
        }


        private GetCategoryService _getCategoryService;
        public GetCategoryService GetCategoryService
        {
            get
            {
                return _getCategoryService = _getCategoryService ?? new GetCategoryService(_context);
            }
        }


        private RemoveCategoryServices _removeCategoryServices;
        public RemoveCategoryServices RemoveCategoryServices
        {
            get
            {
                return _removeCategoryServices = _removeCategoryServices ?? new RemoveCategoryServices(_context);
            }
        }


        private EditCategoryService _editCategoryService;
        public EditCategoryService EditCategoryService
        {
            get
            {
                return _editCategoryService = _editCategoryService ?? new EditCategoryService(_context);
            }
        }
    }
}
