using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Categories.Command.EditCategory
{
    public class EditCategoryService : IEditCategoryServices
    {
        private readonly IDataBaseContext _context;
        public EditCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(RequestEditCategoryDto request)
        {
            var category = _context.Categories.Find(request.Id);
            if (category == null)
            {
                return new RegisterDto()
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }

            category.UpdateTime = DateTime.Now;
            category.Name = request.Name;
            _context.SaveChanges();


            return new RegisterDto()
            {
                IsSuccess = true,
                Message = "تغییرات با موفقیت ذخیره شد"
            };
        }
    }

    public class RequestEditCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
