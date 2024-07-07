using System.Security.Cryptography;

namespace Console_Project.Models;

public class User : BaseEntity
{
    private static int _id;

    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string fullname, string email, string password)
    {
        Id = ++_id;
        FullName = fullname;
        Email = email;
        Password = password;
    }

}
