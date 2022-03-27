using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Users.Commands.ChangeActivityUser
{
    public class ChangeActivityService : IChangeActivityService
    {
        private readonly IDataBaseContext _context;
        public ChangeActivityService(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(int Id)
        {
            var user = _context.Users.Find(Id);

            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }

            _context.SaveChanges();

            return new RegisterDto
            {
                IsSuccess = true,
                Message = "عملیات موفق"
            };


        }
    }
}
