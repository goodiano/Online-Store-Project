using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Users.Commands;
using TemplateProjectOne.Application.Services.Users.Commands.ChangeActivityUser;
using TemplateProjectOne.Application.Services.Users.Commands.RemoveUser;
using TemplateProjectOne.Application.Services.Users.Queries;
using TemplateProjectOne.Application.Services.Users.Queries.GetRoles;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IEditUserServices _editUserServices;
        private readonly IChangeActivityService _changeActivityService;
        private readonly ICategoryFacadPattern _categoryFacadPattern;



        public UsersController(
            IGetUsersService getUsersService, 
            IGetRolesService getRolesService, 
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IEditUserServices editUserServices,
            IChangeActivityService changeActivityService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _editUserServices = editUserServices;
            _changeActivityService = changeActivityService;
        }

        
        public IActionResult Index(string searchKey, int page)
        {
            return View(_getUsersService.Excute(new RequestGetUserDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data,"Id","Name");
            return View();
        }

        //

        [HttpPost]
        public IActionResult Create(string Email, string Name, int Roles, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                Name = Name,
                Roles = new List<RolesRegisterUser>()
                   {
                        new RolesRegisterUser
                        {
                             Id = Roles
                        }
                   },
                Password = Password,
                RePassword = RePassword
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return Json(_removeUserService.Execute(Id));
        }

        public IActionResult Edit(int Id, string name, string email, string password)
        {
            return Json(_editUserServices.Execute(new RequestEditUserDto
            {
                Id = Id,
                Name = name,
                Email = email,
                Password = password
            }));
        }

        public IActionResult UserSatusChange(int Id)
        {
            return Json(_changeActivityService.Execute(Id));
        }
    }
}
