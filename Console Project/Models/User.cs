namespace Console_Project.Models;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string fullname, string email, string password)
    {
        FullName = fullname;
        Email = email;
        Password = password;
    }

}
