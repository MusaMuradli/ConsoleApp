using Console_Project;
using Console_Project.Exceptions;
using Console_Project.Models;
using Console_Project.Services;
using System.Text.RegularExpressions;
using System.Threading.Channels;

UserService userService = new UserService();
MedicineService medicineService = new MedicineService();
CategoryService categoryService = new CategoryService();


restart:
Console.WriteLine("Menu 1: ");
Console.WriteLine("1.User Registration");
Console.WriteLine("2.User Login");
Console.WriteLine("0.Exit");
Console.WriteLine("Enter your choice: ");


string menyuStart = Console.ReadLine();

switch (menyuStart)
{
    case "1":
    bash:
        Console.WriteLine("Enter the fullname");
        string fullname = Console.ReadLine();
        try
        {
            if (fullname.Length < 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Ad minimum 4 herfden ibaret olmalıdır.");
            }
            if (fullname.Length > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Ad maksimum 10 herfden ibaret olmalıdır.");
            }
            if (!fullname.Any(char.IsUpper))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Adda en azı bir böyük herf olmalıdır.");
            }
            if (!fullname.Any(char.IsLower))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Adda en azı bir kiçik herf olmalıdır.");
            }

            Console.WriteLine("Daxil edilen ad: " + fullname);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta: " + ex.Message);
            Console.ResetColor();
            goto bash;
        }
    emailBash:
        Console.WriteLine("Enter the email");
        string email = Console.ReadLine();
        string pattern = @"^[a-z0-9._%+-]+@gmail\.com$";

        if (Regex.IsMatch(email, pattern))
        {

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Email yanlışdır. Email @gmail.com ile bitmeli ve böyük herf olmamalıdır.");
            Console.ResetColor();
            goto emailBash;
        }
    passwordBash:
        Console.WriteLine("Enter the password");
        string password = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, (password.Length - 1));
                Console.Write("\b \b");
            }
        }
        while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        try
        {
            if (password.Length < 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Parol minimum 5 simvoldan ibaret olmalıdır.");
            }
            if (password.Length > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Parol maksimum 10 simvoldan ibaret olmalıdır.");
            }
            if (!password.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Parolda en azı bir reqem olmalıdır.");
            }

            User user = new(fullname, email, password);
            userService.AddUser(user);
            goto restart;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta: " + ex.Message);
            Console.ResetColor();
            goto passwordBash;
        }

    case "2":
        User adminUser = null;
        while (adminUser == null)
        {
            Console.WriteLine("ENTER EMAIL: ");
            string confimEmail = Console.ReadLine();
            Console.WriteLine("ENTER PASSWORD: ");
            string confimPassword = Console.ReadLine();
            try
            {
                adminUser = userService.Login(confimEmail, confimPassword);
                Console.WriteLine("Girish olundu: \n");
                break;
            }
            catch (NotFoundException q)
            {
                Console.WriteLine(q.Message);
            }
        }

        break;
    case "0":
        return;
  
    default:
        goto restart;

        
}

bool stop = false;
menyu1:
Console.WriteLine("Menu:");
Console.WriteLine("1. Create Category");
Console.WriteLine("2. Create Medicine");
Console.WriteLine("3. List All Medicines");
Console.WriteLine("4. Get Medicine By Id");
Console.WriteLine("5. Get Medicine By Name");
Console.WriteLine("6. Get Medicine By Category");
Console.WriteLine("7. Remove Medicine");
Console.WriteLine("8. Update Medicine");
Console.WriteLine("9. Exit");
Console.WriteLine("10. Menyu goster:");
menyu2:
while (!stop)
{
    string getStart = Console.ReadLine();
    switch (getStart)
    {
        case "1":
            Category category = new Category();
            Console.WriteLine("Kateqoriya adi daxil edin");
            category.Name = Console.ReadLine();
            categoryService.CreateCategory(category);
            Console.WriteLine($"{category.Name} adli category elave olundu");
            Console.WriteLine("Esas menyuya qayidmaq isdeyirsinizmi? yes/no");
            break;

        case "yes":
            goto menyu1;
            break;
        case "no":
            goto menyu2;
            break;
        default:
            break;
    }

}





































