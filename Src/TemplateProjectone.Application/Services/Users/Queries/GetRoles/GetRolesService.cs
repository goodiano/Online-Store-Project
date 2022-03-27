using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }

        public RegisterDto<List<GetRolesDto>> Execute()
        {
            var roles = _context.Roles.Select(p=> new GetRolesDto
            {
                Id= p.Id,
                Name = p.Name
            }).ToList();

            return new RegisterDto<List<GetRolesDto>>
            {
                Data = roles,
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }

        
    }
}
