
using Console_Project.Exceptions;
using Console_Project.Models;

namespace Console_Project.Services
{
    public class UserService
    {
        public User Login(string username, string password)
        {
            foreach (var item in DB.Users)
            {
                if (item.FullName == username && item.Password==password)
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

        }
    }
}
