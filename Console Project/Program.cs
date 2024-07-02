using Console_Project;
using Console_Project.Exceptions;
using Console_Project.Models;
using Console_Project.Services;

UserService userService = new UserService();
MedicineService medicineService = new MedicineService();
CategoryService categoryService = new CategoryService();

User user = new User { FullName = "Admin", Email = "admin", Password = "admin123" };

userService.AddUser(user);

User adminUser = null;
while (adminUser == null)
{
    Console.WriteLine("ENTER EMAIL: ");
    string email = Console.ReadLine();


    Console.WriteLine("ENTER PASSWORD: ");
    string password = Console.ReadLine();

    try
    {
        adminUser = userService.Login(email, password);
        Console.WriteLine("Girish olundu: \n");
    }
    catch (NotFoundException q)
    {

        Console.WriteLine(q.Message);
    }
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





































