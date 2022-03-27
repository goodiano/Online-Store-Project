using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Common.GetItemMenu
{
    public class GetItemMenuServices : IGetItemMenuServices
    {
        private readonly IDataBaseContext _context;
        public GetItemMenuServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<ItemMenuDto>> Execute()
        {
            var category = _context.Categories
                .Include(p => p.SubCategory)
                .Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new ItemMenuDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Child = p.SubCategory.ToList().Select(child => new ItemMenuDto
                    {
                        Id = child.Id,
                        Name = child.Name
                    }).ToList(),
                }).ToList();

            return new RegisterDto<List<ItemMenuDto>>
            {
                Data = category,
                IsSuccess = true
            };
        }
    }
}
