using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Product;

namespace TemplateProjectOne.Application.Services.Product.Categories.Command
{
    public class AddNewCategoriesServices : IAddNewCategoriesServices
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoriesServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(int? parentId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new RegisterDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام را وارد کنید"
                };
            }

            Category category = new Category()
            {
                Name = name,
                ParentCategory = GetParentId(parentId)
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return new RegisterDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };

        }
        private Category GetParentId(int? parentId)
        {
            return _context.Categories.Find(parentId);
        }



    }
}
