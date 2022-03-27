using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Common.GetHomePageImages
{
    public class GetHomePageImageServices : IGetHomePageImageServices
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImageServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<List<GetHomePageImageDto>> Execute()
        {
            var PageImage = _context.HomePageImages.OrderByDescending(p => p.Id)
                .Select(p => new GetHomePageImageDto
                {
                    Id = p.Id,
                    LocationImages = p.LocationImages,
                    Description = p.Description,
                    Link = p.Link,
                    Price = p.Price,
                    Src = p.Src,
                    Title = p.Title,
                }).ToList();

            return new RegisterDto<List<GetHomePageImageDto>>
            {
                Data = PageImage,
                IsSuccess = true
            };
        }
    }
}
