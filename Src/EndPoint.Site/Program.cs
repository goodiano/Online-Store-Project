using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Common.GetCategory;
using TemplateProjectOne.Application.Services.Common.GetItemMenu;
using TemplateProjectone.Application.Services.HomePages.Query.GetSliders;
using TemplateProjectOne.Application.Services.HomePages;
using TemplateProjectOne.Application.Services.HomePages.Command.DeleteSlider;
using TemplateProjectOne.Application.Services.HomePages.Command.EditSlider;
using TemplateProjectOne.Application.Services.Product.Categories.FasadPattern;
using TemplateProjectOne.Application.Services.Product.Product.Command;
using TemplateProjectOne.Application.Services.Product.Product.FacadPattern;
using TemplateProjectOne.Application.Services.Users.Commands;
using TemplateProjectOne.Application.Services.Users.Commands.ChangeActivityUser;
using TemplateProjectOne.Application.Services.Users.Commands.RemoveUser;
using TemplateProjectOne.Application.Services.Users.Commands.SignIn;
using TemplateProjectOne.Application.Services.Users.Commands.SignUp;
using TemplateProjectOne.Application.Services.Users.Queries;
using TemplateProjectOne.Application.Services.Users.Queries.GetRoles;
using TemplateProjectOne.Persistance.Context;
using TemplateProjectone.Application.Services.HomePages.Command.AddHomePageImages;
using TemplateProjectOne.Application.Services.Common.GetHomePageImages;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IDataBaseContext , DataBaseContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

#region IOC
builder.Services.AddScoped<IDataBaseContext , DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IEditUserServices, EditUserServices>();
builder.Services.AddScoped<IChangeActivityService, ChangeActivityService>();
builder.Services.AddScoped<ISignInUserServices, SignInUserServices>();
builder.Services.AddScoped<ISignUpUserServices, SignUpUserServices>();
builder.Services.AddScoped<ICategoryFacadPattern, CategoryFasad>();
builder.Services.AddScoped<IProductFacadPattern, ProductFacad>();
builder.Services.AddScoped<IProductForSiteFacadPattern, ProductForSiteFacad>();
builder.Services.AddScoped<IAddSliderServices, AddSliderServices>();
builder.Services.AddScoped<IGetSliderServices, GetSliderServices>();
builder.Services.AddScoped<IDeleteSliderServices, DeleteSliderServices>();
builder.Services.AddScoped<IEditSliderServices, EditSliderServices>();
builder.Services.AddScoped<IAddHomePageImageServices, AddHomePageImageServices>();
builder.Services.AddScoped<IGetHomePageImageServices, GetHomePageImageServices>();






//____________________
builder.Services.AddScoped<IGetItemMenuServices, GetItemMenuServices>();
builder.Services.AddScoped<IGetCategoryServices, GetCategoryServices>();
#endregion

#region ConnectionString
string connectionString = "Server =.; Database =TemplateProjectOne; User Id =sa; Password =136754744;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Users}/{action=Index}/{id?}");
         

app.Run();
