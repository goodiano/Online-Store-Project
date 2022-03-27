namespace TemplateProjectOne.Application.Services.Users.Queries
{
    public class GetUsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
