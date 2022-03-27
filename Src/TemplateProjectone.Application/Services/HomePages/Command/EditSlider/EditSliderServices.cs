using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.HomePages.Command.EditSlider
{
    public class EditSliderServices : IEditSliderServices
    {
        private readonly IDataBaseContext _context;
        public EditSliderServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(RequestEditSliderDto request)
        {
            var slider = _context.Sliders.Find(request.Id);
            if(slider == null)
            {
                new RegisterDto
                {
                    IsSuccess = false,
                    Message = "اسلایدر یافت نشد"
                };
            }

            slider.Link = request.Link;
            slider.Title = request.Title;
            slider.Description = request.Description;
            slider.UpdateTime = DateTime.Now;
            _context.SaveChanges();

            return new RegisterDto()
            {
                IsSuccess= true
            };
        }
    }
}