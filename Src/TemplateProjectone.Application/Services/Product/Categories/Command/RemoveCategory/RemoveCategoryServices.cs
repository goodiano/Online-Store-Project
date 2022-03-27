using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Categories.Command.RemoveCategory
{
    public class RemoveCategoryServices : IRemoveCategoryServices
    {
        private readonly IDataBaseContext _context;

        public RemoveCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(int Id)
        {
            var category = _context.Categories.Find(Id);

            if (category.ParentCategoryId == null)
            {

                var parents = _context.Categories
                .OrderBy(e => e.Id)
                .Include(e => e.SubCategory)
                .First();

                _context.Categories.Remove(parents);
                _context.SaveChanges();

                return new RegisterDto
                {
                    IsSuccess = true,
                    Message = "حذف با موفقیت انجام شد"
                };

            }
            else
            {
                if (category.ParentCategoryId != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();

                    return new RegisterDto
                    {
                        IsSuccess = true,
                        Message = "عملیات حذف موفق بود"
                    };
                }
            }

            return new RegisterDto
            {
                IsSuccess = false,
                Message = "عملیات موفق نبود"
            };
        }
    }
}
