using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Common.HashPassword;

namespace TemplateProjectOne.Application.Services.Users.Commands.SignIn
{
    public class SignInUserServices : ISignInUserServices
    {
        private readonly IDataBaseContext _context;
        public SignInUserServices(IDataBaseContext context)
        {
            _context = context;
        }

        public RegisterDto<LoginUserDto> Execute(string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                return new RegisterDto<LoginUserDto>()
                {
                    Data = new LoginUserDto()
                    {
                       
                    },
                    IsSuccess = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید",
                };
            }

            var user = _context.Users
             .Include(p => p.UserInRoles)
             .ThenInclude(p => p.Roles)
             .Where(p => p.Email.Equals(Email)
              && p.IsActive == true)
             .FirstOrDefault();

            

            if (user == null)
            {
                return new RegisterDto<LoginUserDto>()
                {
                    Data = new LoginUserDto()
                    {
                       
                    },
                    IsSuccess = false,
                    Message = "کاربری با این ایمیل در سایت ثبت نام نکرده است",
                };
            }

            var passwordHasher = new PasswordHasher();
            bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, Password);
            if (resultVerifyPassword == false)
            {
                return new RegisterDto<LoginUserDto>()
                {
                    Data = new LoginUserDto()
                    {
                    },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",
                };
            }


            List<string> roles = new List<string>();
            foreach (var item in user.UserInRoles)
            {
                roles.Add(item.Roles.Name);
            }


            return new RegisterDto<LoginUserDto>()
            {
                Data = new LoginUserDto()
                {
                    Role = roles,
                    Id = user.Id,
                    Name = user.Name
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };
        }


    }
}

