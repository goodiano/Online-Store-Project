namespace TemplateProjectOne.Application.Services.Users.Commands.SignIn
{
    public class LoginUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Role { get; set; }
    }
}
