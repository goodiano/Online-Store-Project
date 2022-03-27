using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectone.Application.Services.HomePages.Query.GetSliders
{
    public class GetSliderServices : IGetSliderServices
    {
        private readonly IDataBaseContext _context;
        public GetSliderServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<GetSliderDto>> Execute()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.Id).Select(p =>
             new GetSliderDto
             {
                 Src = p.Src,
                 Link = p.Link,
                 Title = p.Title,
                 Description = p.Description
             }
            ).ToList();

            return new RegisterDto<List<GetSliderDto>>
            {
                Data = sliders,
                IsSuccess = true
            };
        }
    }
} 
