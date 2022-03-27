using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.HomePages.Command.DeleteSlider
{
    public class DeleteSliderServices : IDeleteSliderServices
    {
        private readonly IDataBaseContext _context;
        public DeleteSliderServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(int Id)
        {
            var slider = _context.Sliders.Find(Id);
               
            if(slider == null)
            {
                return new RegisterDto
                {
                    IsSuccess = false,
                    Message = "اسلایدر یافت نشد"
                };
            }

            slider.IsRemoved = true;
            slider.RemoveTime = DateTime.Now;
            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return new RegisterDto
            {
                IsSuccess = true,
            };
        }
    }
}
