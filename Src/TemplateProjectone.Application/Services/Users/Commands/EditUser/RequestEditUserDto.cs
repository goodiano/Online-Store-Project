namespace TemplateProjectOne.Application.Services.Users.Commands
{
    public class RequestEditUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
