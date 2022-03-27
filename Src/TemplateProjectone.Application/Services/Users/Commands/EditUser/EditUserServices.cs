using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Common.HashPassword;

namespace TemplateProjectOne.Application.Services.Users.Commands
{
    public class EditUserServices : IEditUserServices
    {
        private readonly IDataBaseContext _context;
        public EditUserServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(RequestEditUserDto request)
        {
            var user = _context.Users.Find(request.Id);
            if (user == null)
            {
                return new RegisterDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            var PasswordHasher = new PasswordHasher();

            user.UpdateTime = DateTime.Now;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = PasswordHasher.HashPassword(request.Password);
            _context.SaveChanges();

            return new RegisterDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
