using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Common.HashPassword;
using TemplateProjectOne.Domain.Entities.Users;

namespace TemplateProjectOne.Application.Services.Users.Commands
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<RegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new RegisterDto<RegisterUserDto>()
                    {
                        Data = new RegisterUserDto()
                        {
                            userId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new RegisterDto<RegisterUserDto>()
                    {
                        Data = new RegisterUserDto()
                        {
                            userId = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید"
                    };
                }


                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new RegisterDto<RegisterUserDto>()
                    {
                        Data = new RegisterUserDto()
                        {
                            userId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new RegisterDto<RegisterUserDto>()
                    {
                        Data = new RegisterUserDto()
                        {
                            userId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }

                var PasswordHasher = new PasswordHasher();

                User user = new User()
                {
                    Email = request.Email,
                    Name = request.Name,
                    Password = PasswordHasher.HashPassword(request.Password)
                };

                List<UserInRole> userInRoles = new List<UserInRole>();

                foreach (var item in request.Roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        Roles = roles,
                        RoleId = roles.Id,
                        Users = user,
                        UserId = user.Id,
                    });
                }
                user.UserInRoles = userInRoles;

                _context.Users.Add(user);

                _context.SaveChanges();

                return new RegisterDto<RegisterUserDto>()
                {
                    Data = new RegisterUserDto()
                    {
                        userId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };
            }
            catch (Exception)
            {
                return new RegisterDto<RegisterUserDto>()
                {
                    Data = new RegisterUserDto()
                    {
                        userId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }
}
