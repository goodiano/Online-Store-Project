using EndPoint.Site.Models.ViewModel.AuthenticationViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;
using TemplateProjectOne.Application.Services.Users.Commands.SignIn;
using TemplateProjectOne.Application.Services.Users.Commands.SignUp;
using TemplateProjectOne.Common.Dto;


namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ISignUpUserServices _signUpUserServices;
        private readonly ISignInUserServices _signInUserServices;
        public AuthenticationController(ISignUpUserServices signUpUserServices, ISignInUserServices signInUserServices)
        {
            _signUpUserServices = signUpUserServices;
            _signInUserServices = signInUserServices;
        }

        public IActionResult SignIn(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string Email, string Password)
        {
            var user = _signInUserServices.Execute(Email, Password);
            if (user.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Data.Id.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, user.Data.Name),
                new Claim(ClaimTypes.Role, "Customer"),
            };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {          
            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new RegisterDto { IsSuccess = false, Message = "شما وارد شده اید. نیازی به ثبت نام مجدد نیست" });
            }

            var user = _signUpUserServices.Ecexute(new RequestRegisterUserDto
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RolesRegisterUser>()
                {
                    new RolesRegisterUser { Id = 3 }
                }
            });

            if (user.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Data.userId.ToString()),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, request.Name),
                new Claim(ClaimTypes.Role, "Customer"),
            };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(user);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
