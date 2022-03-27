public class RequestRegisterUserDto
    {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public List<RolesRegisterUser> Roles { get; set; }

    }
