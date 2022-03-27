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
        public AuthenticationController(ISignUpUserServices signUpUserServices , ISignInUserServices signInUserServices)
        {
            _signUpUserServices = signUpUserServices;
            _signInUserServices = signInUserServices;
        }

        public IActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string Email , string Password)
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

            return View(user);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            if (string.IsNullOrEmpty(request.FullName) ||
                string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.RePassword))
            {
                return Json(new RegisterDto() { IsSuccess = false, Message = "لطفا تمامی موارد را وارد نمایید" });
            }

            if (request.Password != request.RePassword)
            {
                return Json(new RegisterDto { IsSuccess = false, Message = "رمز عبور و تکرار آن یکسان نیست" });
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new RegisterDto { IsSuccess = false, Message = "شما وارد شده اید. نیازی به ثبت نام مجدد نیست" });
            }

            if (request.Password.Length < 8)
            {
                return Json(new RegisterDto { IsSuccess = false, Message = "رمز عبور باید بیشتر از 8 کاراکتر باشد" });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(request.Email, emailRegex); 
            if(!match.Success)
            {
                return Json(new RegisterDto { IsSuccess = false, Message = "لطفا ایمیل صحیحی را وارد کنید مثل: test@gmail.com" });
            }

            var user = _signUpUserServices.Ecexute(new RequestRegisterUserDto
            {
                Name = request.FullName,
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
                new Claim(ClaimTypes.Name, request.FullName),
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

            return View(user);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
