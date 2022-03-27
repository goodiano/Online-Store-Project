using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Categories.Query.GetCategory
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _context;
        public GetCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<GetCategoryDto>> Execute(int? ParentId)
        {
            var category = _context.Categories
                  .Include(p => p.ParentCategory)
                  .Include(p => p.SubCategory)
                  .Where(p => p.ParentCategoryId == ParentId)
                  .ToList()
                  .Select(p => new GetCategoryDto
                  {
                      Id = p.Id,
                      Name = p.Name,
                      parent = p.ParentCategory != null ? new
                      ParentCategoryDto
                      {
                          Id = p.ParentCategory.Id,
                          Name = p.ParentCategory.Name
                      }
                      : null,
                      HasChild = p.SubCategory.Count() > 0 ? true : false
                  }).ToList();


            return new RegisterDto<List<GetCategoryDto>>
            {
                Data = category,
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
                  
        }
    }


}
