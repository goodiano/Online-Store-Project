using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;
        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(int Id)
        {
            var user = _context.Users.Find(Id);
            if (user == null)
            {
               return new RegisterDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();

            return new RegisterDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
