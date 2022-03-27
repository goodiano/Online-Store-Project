using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common;

namespace TemplateProjectOne.Application.Services.Users.Queries
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUserDto Excute(RequestGetUserDto request)
        {
            //Craete a query
            var users = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users.Where(p=> p.Name.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            
            //Pagination and SelectUser
            int rowsCount = 0;      
            var usersList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                IsActive = p.IsActive,
                Password = p.Password
            }).ToList();


            return new ResultGetUserDto
            {
                Rows = rowsCount,
                ListUsers = usersList
            };
        }
    }
}
