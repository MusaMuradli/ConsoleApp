
using Console_Project.Exceptions;
using Console_Project.Models;

namespace Console_Project.Services
{
    public class UserService
    {
        public User Login(string email, string password)
        {
            foreach (var item in DB.Users)
            {
                if (item.Email == email && item.Password==password)
                {
                    return item;
                }

            }
            throw new NotFoundException("User tapilmadi");
        }
        public void  AddUser(User user)
        {
            Array.Resize(ref DB.Users, DB.Users.Length+1);
            DB.Users[DB.Users.Length-1] = user;

            Console.WriteLine("User succesfully added");

        }
    }
}
