using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Common.GetCategory
{
    public class GetCategoryServices : IGetCategoryServices
    {
        private readonly IDataBaseContext _context;
        public GetCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<GetCategoryDto>> Execute()
        {
            var category = _context.Categories
                 .Where(p => p.ParentCategory == null)
                 .Select(p => new GetCategoryDto
                 {
                     CatId = p.Id,
                     CategoryName = p.Name
                 }).ToList();

            return new RegisterDto<List<GetCategoryDto>>
            {
                Data = category,
                IsSuccess = true
            };
        }
    }
}
